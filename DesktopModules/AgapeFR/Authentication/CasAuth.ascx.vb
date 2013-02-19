﻿Imports System.IO
Imports System.Xml
Imports System.Net
Imports DotNetNuke.Entities.Tabs
Imports DotNetNuke.Security.Permissions
Imports DotNetNuke.UI.Skins
Imports DotNetNuke.UI.Utilities
Imports DotNetNuke.Security.Membership
Imports DotNetNuke.Services.Authentication
Imports System.Linq


Namespace DotNetNuke.Modules.AgapeFR.Authentication
    Partial Class CasAuth
        Inherits Entities.Modules.PortalModuleBase
        Dim CASHOST As String = "https://thekey.me/cas/"

#Region "Properties"

        Public ReadOnly Property Service As String
            Get
                Return Request.UrlReferrer.ToString 'TabController.CurrentPage.FullUrl
            End Get
        End Property

#End Region

        Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
            ' Init translation resource file
            AgapeTranslation.InitLocalResourceFile(Me)
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Request.QueryString("mode") = "host" Then

                ' Response.Write(Service)

            End If

            'Look for the "ticket=" after the "?" in the URL
            Dim tkt As String = Request.QueryString("ticket")
            If Not (tkt Is Nothing) Then
                StaffLogin()
            End If

        End Sub

        Public Sub StaffLogin()
            Dim returnURL As String = Session("returnurl")
            Dim PS = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Dim tkt As String = Request.QueryString("ticket")

            ' Second time (back from CAS) there is a ticket= to validate
            Dim validateurl As String = CASHOST + "proxyValidate?" & "ticket=" & tkt & "&" & "service=" & Service & "&pgtUrl=https://myagape.org.uk/pgtCallback.aspx"
            Dim Reader1 As StreamReader = New StreamReader(New WebClient().OpenRead(validateurl))
            Dim doc As New XmlDocument()
            doc.Load(Reader1)
            Dim NamespaceMgr As New XmlNamespaceManager(doc.NameTable)
            NamespaceMgr.AddNamespace("cas", "http://www.yale.edu/tp/cas")
            'Check for success
            Dim ServiceResponse As XmlNode = doc.SelectSingleNode("/cas:serviceResponse/cas:authenticationFailure", NamespaceMgr)
            If Not ServiceResponse Is Nothing Then
                Response.Write("Error: " & ServiceResponse.InnerText)
                Return
            End If

            Dim SuccessNode As XmlNode = doc.SelectSingleNode("/cas:serviceResponse/cas:authenticationSuccess", NamespaceMgr)

            If Not SuccessNode Is Nothing Then 'User Is authenticated
                Dim netid As String = String.Empty

                Dim firstName As String = String.Empty
                Dim lastName As String = String.Empty
                Dim ssoGUID As String = String.Empty
                Dim PGTIOU As String = String.Empty

                If Not SuccessNode.SelectSingleNode("./cas:user", NamespaceMgr) Is Nothing Then
                    netid = SuccessNode.SelectSingleNode("./cas:user", NamespaceMgr).InnerText
                End If
                If Not SuccessNode.SelectSingleNode("./cas:attributes/firstName", NamespaceMgr) Is Nothing Then
                    firstName = SuccessNode.SelectSingleNode("./cas:attributes/firstName", NamespaceMgr).InnerText
                End If
                If Not SuccessNode.SelectSingleNode("./cas:attributes/lastName", NamespaceMgr) Is Nothing Then
                    lastName = SuccessNode.SelectSingleNode("./cas:attributes/lastName", NamespaceMgr).InnerText
                End If
                If Not SuccessNode.SelectSingleNode("./cas:attributes/ssoGuid", NamespaceMgr) Is Nothing Then
                    ssoGUID = SuccessNode.SelectSingleNode("./cas:attributes/ssoGuid", NamespaceMgr).InnerText
                End If
                If Not SuccessNode.SelectSingleNode("./cas:proxyGrantingTicket", NamespaceMgr) Is Nothing Then

                    PGTIOU = SuccessNode.SelectSingleNode("./cas:proxyGrantingTicket", NamespaceMgr).InnerText

                End If



                ' If there was a problem, leave the message on the screen. Otherwise, return to original page.
                If (netid = String.Empty) Then

                    Response.Write("There was an error during login.")
                Else
                    'If netid = "jon@vellacott.co.uk" Then

                    '    Response.Write(Server.HtmlEncode(doc.OuterXml))

                    '    Response.Write("PGTIOU" & Session("PGTIOU"))
                    '    Return
                    'End If
                    Dim email = netid


                    netid = netid & PS.PortalId



                    'For the public portal, we need to check if they are already registered.

                    Dim objUserCreateStatus As UserCreateStatus

                    Dim objUserInfo As UserInfo
                    'See if user exists in DNN Portal user DB
                    objUserInfo = UserController.GetUserByName(CType(HttpContext.Current.Items("PortalSettings"), PortalSettings).PortalId, netid)

                    'user doesn't exist - try to create on the fly
                    If (objUserInfo Is Nothing) Then
                        'User doesn't exists. Lets try looking up the GUID, to see if they have just changed their login email.
                        If ssoGUID <> String.Empty Then
                            Dim UID As Integer = GetUIDFromGUID(ssoGUID)
                            If UID > 0 Then
                                objUserInfo = UserController.GetUserById(PS.PortalId, UID)
                                If (Not objUserInfo Is Nothing) Then

                                    LoginUser(objUserInfo, PS, returnURL)
                                    'FormsAuthentication.RedirectFromLoginPage(netid, False) 'set netid in ASP.NET blocks

                                End If
                            End If

                        End If

                        'Create the New User
                        objUserInfo = New UserInfo()




                        objUserInfo.FirstName = firstName
                        objUserInfo.LastName = lastName
                        objUserInfo.DisplayName = firstName & " " & lastName
                        objUserInfo.Username = netid
                        objUserInfo.PortalID = PS.PortalId
                        objUserInfo.Membership.Password = UserController.GeneratePassword(8)
                        objUserInfo.Email = email
                        objUserCreateStatus = UserController.CreateUser(objUserInfo)
                        If objUserCreateStatus <> UserCreateStatus.Success Then
                            Response.Write("Error creating Agape Account:- " & objUserCreateStatus.ToString)

                        Else
                            If ssoGUID <> String.Empty Then
                                StaffBrokerFunctions.SetUserProfileProperty(PortalId, objUserInfo.UserID, "ssoGUID", ssoGUID)
                            End If
                            If PGTIOU <> String.Empty Then
                                StaffBrokerFunctions.SetUserProfileProperty(PortalId, objUserInfo.UserID, "GCXPGTIOU", PGTIOU)
                            End If

                            LoginUser(objUserInfo, PS, returnURL)
                            'FormsAuthentication.RedirectFromLoginPage(netid, False) 'set netid in ASP.NET blocks

                        End If


                    Else

                        If ssoGUID <> String.Empty Then
                            StaffBrokerFunctions.SetUserProfileProperty(PortalId, objUserInfo.UserID, "ssoGUID", ssoGUID)
                        End If
                        If PGTIOU <> String.Empty Then
                            StaffBrokerFunctions.SetUserProfileProperty(PortalId, objUserInfo.UserID, "GCXPGTIOU", PGTIOU)
                        End If


                        LoginUser(objUserInfo, PS, returnURL)
                        'FormsAuthentication.RedirectFromLoginPage(netid, False) 'set netid in ASP.NET blocks


                    End If
                End If
            End If
        End Sub

        Private Sub LoginUser(ByVal objUserInfo As UserInfo, ByVal PS As PortalSettings, ByVal returnURL As String)
            If returnURL Is Nothing Then
                FormsAuthentication.RedirectFromLoginPage(objUserInfo.Username, False)
            Else
                UserController.UserLogin(PortalSettings.PortalId, objUserInfo, PortalSettings.PortalName, AuthenticationLoginBase.GetIPAddress(), False)

                Response.Redirect(HttpUtility.UrlDecode(returnURL))

            End If

        End Sub

        Private Sub SetPGTIOU(ByVal UserId As Integer, ByVal Value As String)
            '  SetProfileProperty("GCXPGTIOU", UserId, Value)
            'Dim PS = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            'Dim theUser = UserController.GetUserById(PS.PortalId, UserId)

            'theUser.Profile.SetProfileProperty("GCXPGTIOU", Value)

        End Sub

        'Private Function GetStaffProfileProperty(ByVal PropertyName As String, ByVal UserId As Integer) As String

        '    Dim answer = From c In d.UserProfiles Where c.UserID = UserId And c.ProfilePropertyDefinition.PropertyName = PropertyName And c.ProfilePropertyDefinition.PortalID = 0 Select c.PropertyValue
        '    If answer.Count > 0 Then
        '        Return answer.First
        '    Else
        '        Return String.Empty
        '    End If

        'End Function

        Private Sub SetGUID(ByVal UserId As Integer, ByVal Value As String)
            '     SetProfileProperty("ssoGUID", UserId, Value)
            'Dim PS = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            'Dim theUser = UserController.GetUserById(PS.PortalId, UserId)

            'theUser.Profile.SetProfileProperty("ssoGUID", Value)

        End Sub

        Private Function GetUIDFromGUID(ByVal ssoGUID As String) As Integer


            Dim PS = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)
            Dim totalRecords As New Integer
            Dim q = UserController.GetUsersByProfileProperty(PS.PortalId, "ssoGUID", ssoGUID, 1, 1000, totalRecords)

            If q.Count > 0 Then
                Return CType(q(0), UserInfo).UserID
            Else
                Return -1
            End If

        End Function


        Private Sub SetProfileProperty(ByVal PropertyName As String, ByRef theUser As UserInfo, ByVal Value As String)
            Dim PS = CType(HttpContext.Current.Items("PortalSettings"), PortalSettings)

            If DotNetNuke.Entities.Profile.ProfileController.GetPropertyDefinitionByName(PS.PortalId, PropertyName) Is Nothing Then
                Dim insert As New DotNetNuke.Entities.Profile.ProfilePropertyDefinition()

                insert.ModuleDefId = -1
                insert.Deleted = False
                insert.DataType = 349
                insert.DefaultValue = ""
                insert.PropertyCategory = "Authentication"
                insert.PropertyName = PropertyName
                insert.Length = 50
                insert.Required = False
                insert.ViewOrder = 100
                insert.PortalId = PS.PortalId
                insert.DefaultVisibility = 0


                DotNetNuke.Entities.Profile.ProfileController.AddPropertyDefinition(insert)

                theUser.Profile.ProfileProperties.Add(insert)

            End If

            ' theUser.Profile.InitialiseProfile(PS.PortalId)

            theUser.Profile.SetProfileProperty(PropertyName, Value)

            '  UserController.UpdateUser(PS.PortalId, theUser)
        End Sub

        Protected Sub BtnTheKey_Click(sender As Object, e As EventArgs) Handles BtnTheKey.Click

            Dim template = Request.Url.Scheme & "://" & Request.Url.Authority & Request.ApplicationPath & "sso/template-agapebluev2.css"

            ' First time through there is no ticket=, so get returnurl in request and redirect to CAS login
            Dim returnUrl As String = Request.QueryString("returnurl")
            If returnUrl Is Nothing Or returnUrl = "" Then
                Session("returnurl") = HttpUtility.UrlEncode(Request.UrlReferrer.ToString) 'Nothing
            ElseIf Request.RawUrl.Contains(HttpUtility.UrlDecode(returnUrl)) Then
                Session("returnurl") = Nothing
            Else
                Session("returnurl") = returnUrl
            End If

            Dim redirectUrl As String = CASHOST & "/login.htm?service=" & Service & "&template=" & template
            Response.Redirect(redirectUrl)

        End Sub
    End Class
End Namespace
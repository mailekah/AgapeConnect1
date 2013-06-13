﻿Imports DotNetNuke
Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Math
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Collections.Specialized
Imports System.Xml.Linq
Imports System.Linq
Imports System.Data
Imports System.Data.OleDb
Imports Budget
Namespace DotNetNuke.Modules.Budget



    Partial Class BudgetManager
        Inherits Entities.Modules.PortalModuleBase
        Dim d As New BudgetDataContext

        Dim currentFiscalYear As Integer
        Dim firstFiscalMonth As Integer
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            hfPortalId.Value = PortalId

             Dim tmp = StaffBrokerFunctions.GetSetting("FirstFiscalMonth", PortalId)
            If Not String.IsNullOrEmpty(tmp) Then
                firstFiscalMonth = tmp
            End If
            tmp = StaffBrokerFunctions.GetSetting("CurrentFiscalPeriod", PortalId)
            If Not String.IsNullOrEmpty(tmp) Then
                currentFiscalYear = Left(tmp, 4)
            End If
            If (Not Page.IsPostBack) Then
                Dim RCs = From c In d.AP_StaffBroker_CostCenters Where c.PortalId = PortalId Select c.CostCentreCode, Name = c.CostCentreCode & " (" & c.CostCentreName & ")" Order By CostCentreCode

                ddlRC.DataSource = RCs

                ddlRC.DataBind()
                ddlRCNew.DataSource = RCs
                ddlRCNew.DataBind()

                Dim Accs = From c In d.AP_StaffBroker_AccountCodes Where c.PortalId = PortalId Select c.AccountCode, Name = c.AccountCode & " (" & c.AccountCodeName & ")" Order By AccountCode

                ddlAC.DataSource = Accs
                ddlAC.DataBind()


                ddlAccountNew.DataSource = Accs
                ddlAccountNew.DataBind()
                If firstFiscalMonth <> 1 Then
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear - 2) & "-" & (currentFiscalYear - 1), currentFiscalYear - 2))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear - 1) & "-" & (currentFiscalYear), currentFiscalYear - 1))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear) & "-" & (currentFiscalYear + 1), currentFiscalYear))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear + 1) & "-" & (currentFiscalYear + 2), currentFiscalYear + 1))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear + 2) & "-" & (currentFiscalYear + 3), currentFiscalYear + 2))
                Else
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear - 2), currentFiscalYear - 2))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear - 1), currentFiscalYear - 1))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear), currentFiscalYear))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear + 1), currentFiscalYear + 1))
                    ddlFiscalYear.Items.Add(New ListItem((currentFiscalYear + 2), currentFiscalYear + 2))
                End If
                


                ddlFiscalYear.SelectedValue = currentFiscalYear
            End If


        End Sub

        Protected Sub GridView1_DataBound(sender As Object, e As EventArgs) Handles GridView1.DataBound
            Dim q = From c In d.AP_Budget_Summaries Where c.Portalid = PortalId And c.FiscalYear = CInt(ddlFiscalYear.SelectedValue) And (c.RC = ddlRC.SelectedValue Or ddlRC.SelectedValue = "All" Or (ddlRC.SelectedValue = "AllStaff" And c.AP_StaffBroker_CostCenter.Type = 1) Or (ddlRC.SelectedValue = "AllNonStaff" And c.AP_StaffBroker_CostCenter.Type <> 1)) And (ddlAC.SelectedValue = "All" Or c.Account = ddlAC.SelectedValue Or ((ddlAC.SelectedValue = "3" Or ddlAC.SelectedValue = "IE") And c.AP_StaffBroker_AccountCode.AccountCodeType = 3) Or ((ddlAC.SelectedValue = "4" Or ddlAC.SelectedValue = "IE") And c.AP_StaffBroker_AccountCode.AccountCodeType = 4))
            If q.Count > 0 Then
                lblPTD1.Text = q.Sum(Function(c) c.P1).Value.ToString("0.00")
                lblPTD2.Text = q.Sum(Function(c) c.P2).Value.ToString("0.00")
                lblPTD3.Text = q.Sum(Function(c) c.P3).Value.ToString("0.00")
                lblPTD4.Text = q.Sum(Function(c) c.P4).Value.ToString("0.00")
                lblPTD5.Text = q.Sum(Function(c) c.P5).Value.ToString("0.00")
                lblPTD6.Text = q.Sum(Function(c) c.P6).Value.ToString("0.00")
                lblPTD7.Text = q.Sum(Function(c) c.P7).Value.ToString("0.00")
                lblPTD8.Text = q.Sum(Function(c) c.P8).Value.ToString("0.00")
                lblPTD9.Text = q.Sum(Function(c) c.P9).Value.ToString("0.00")
                lblPTD10.Text = q.Sum(Function(c) c.P10).Value.ToString("0.00")
                lblPTD11.Text = q.Sum(Function(c) c.P11).Value.ToString("0.00")
                lblPTD12.Text = q.Sum(Function(c) c.P12).Value.ToString("0.00")

                lblYTD1.Text = q.Sum(Function(c) c.P1).Value.ToString("0.00")
                lblYTD2.Text = q.Sum(Function(c) c.P1 + c.P2).Value.ToString("0.00")
                lblYTD3.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3).Value.ToString("0.00")
                lblYTD4.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4).Value.ToString("0.00")
                lblYTD5.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5).Value.ToString("0.00")
                lblYTD6.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5 + c.P6).Value.ToString("0.00")
                lblYTD7.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5 + c.P6 + c.P7).Value.ToString("0.00")
                lblYTD8.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5 + c.P6 + c.P7 + c.P8).Value.ToString("0.00")
                lblYTD9.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5 + c.P6 + c.P7 + c.P8 + c.P9).Value.ToString("0.00")
                lblYTD10.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5 + c.P6 + c.P7 + c.P8 + c.P9 + c.P10).Value.ToString("0.00")
                lblYTD11.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5 + c.P6 + c.P7 + c.P8 + c.P9 + c.P10 + c.P11).Value.ToString("0.00")
                lblYTD12.Text = q.Sum(Function(c) c.P1 + c.P2 + c.P3 + c.P4 + c.P5 + c.P6 + c.P7 + c.P8 + c.P9 + c.P10 + c.P11 + c.P12).Value.ToString("0.00")

                lblTotal.Text = lblYTD12.Text
            Else
                lblPTD1.Text = 0
                lblPTD2.Text = 0
                lblPTD3.Text = 0
                lblPTD4.Text = 0
                lblPTD5.Text = 0
                lblPTD6.Text = 0
                lblPTD7.Text = 0
                lblPTD8.Text = 0
                lblPTD9.Text = 0
                lblPTD10.Text = 0
                lblPTD11.Text = 0
                lblPTD12.Text = 0

                lblYTD1.Text = 0
                lblYTD2.Text = 0
                lblYTD3.Text = 0
                lblYTD4.Text = 0
                lblYTD5.Text = 0
                lblYTD6.Text = 0
                lblYTD7.Text = 0
                lblYTD8.Text = 0
                lblYTD9.Text = 0
                lblYTD10.Text = 0
                lblYTD11.Text = 0
                lblYTD12.Text = 0
                lblTotal.Text = 0
            End If
            If Not firstFiscalMonth = Nothing Then

                lblP1.Text = GetCalendarStartForPeriod(1, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP2.Text = GetCalendarStartForPeriod(2, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP3.Text = GetCalendarStartForPeriod(3, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP4.Text = GetCalendarStartForPeriod(4, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP5.Text = GetCalendarStartForPeriod(5, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP6.Text = GetCalendarStartForPeriod(6, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP7.Text = GetCalendarStartForPeriod(7, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP8.Text = GetCalendarStartForPeriod(8, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP9.Text = GetCalendarStartForPeriod(9, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP10.Text = GetCalendarStartForPeriod(10, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP11.Text = GetCalendarStartForPeriod(11, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")
                lblP12.Text = GetCalendarStartForPeriod(12, firstFiscalMonth, ddlFiscalYear.SelectedValue).ToString("MMM ""'""yy")


            End If

        End Sub
       

        Protected Function GetCalendarStartForPeriod(ByVal period As Integer, ByVal firstMonth As Integer, ByVal FiscalYear As Integer) As Date
            If period + firstMonth - 1 <= 12 Then
                Return New Date(FiscalYear, period + firstMonth - 1, 1)
            Else
                Return New Date(FiscalYear + 1, period + firstMonth - 13, 1)
            End If
        End Function

        Protected Sub btnInsertRow_Click(sender As Object, e As EventArgs) Handles btnInsertRow.Click
            Dim q = From c In d.AP_Budget_Summaries Where c.Portalid = PortalId And c.FiscalYear = ddlFiscalYear.SelectedValue And c.Account = ddlAccountNew.SelectedValue And c.RC = ddlRCNew.SelectedValue
            If q.Count = 0 Then
                Dim insert As New AP_Budget_Summary
                insert.Portalid = PortalId
                insert.FiscalYear = ddlFiscalYear.SelectedValue
                insert.Account = ddlAccountNew.SelectedValue
                insert.RC = ddlRCNew.SelectedValue
                insert.P1 = tbP1new.Text
                insert.P2 = tbP2new.Text
                insert.P3 = tbP3new.Text
                insert.P4 = tbP4new.Text
                insert.P5 = tbP5new.Text
                insert.P6 = tbP6new.Text
                insert.P7 = tbP7new.Text
                insert.P8 = tbP8new.Text
                insert.P9 = tbP9new.Text
                insert.P10 = tbP10new.Text
                insert.P11 = tbP11new.Text
                insert.P12 = tbP12new.Text
                insert.Changed = True
                insert.LastUpdated = Now
                d.AP_Budget_Summaries.InsertOnSubmit(insert)
                d.SubmitChanges()
                GridView1.DataBind()

                ddlRCNew.SelectedIndex = 0
                ddlAccountNew.SelectedIndex = 0
                tbP1new.Text = "0"
                tbP2new.Text = "0"
                tbP3new.Text = "0"
                tbP4new.Text = "0"
                tbP5new.Text = "0"
                tbP6new.Text = "0"
                tbP7new.Text = "0"
                tbP8new.Text = "0"
                tbP9new.Text = "0"
                tbP10new.Text = "0"
                tbP11new.Text = "0"
                tbP12new.Text = "0"
                lblTotalNew.Text = "0"
                WarningRow.Visible = False
                btnInsertRow.Visible = True

            Else
                'Budget already exists... replace or addto.
                WarningRow.Visible = True
                btnInsertRow.Visible = False


            End If



        End Sub


        Protected Sub btnCancelInsert_Click(sender As Object, e As EventArgs) Handles btnCancelInsert.Click
            ddlRCNew.SelectedIndex = 0
            ddlAccountNew.SelectedIndex = 0
            tbP1new.Text = "0"
            tbP2new.Text = "0"
            tbP3new.Text = "0"
            tbP4new.Text = "0"
            tbP5new.Text = "0"
            tbP6new.Text = "0"
            tbP7new.Text = "0"
            tbP8new.Text = "0"
            tbP9new.Text = "0"
            tbP10new.Text = "0"
            tbP11new.Text = "0"
            tbP12new.Text = "0"
            lblTotalNew.Text = "0"
            WarningRow.Visible = False
            btnInsertRow.Visible = True
        End Sub



        Protected Sub btnReplace_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
            Dim q = From c In d.AP_Budget_Summaries Where c.Portalid = PortalId And c.FiscalYear = ddlFiscalYear.SelectedValue And c.Account = ddlAccountNew.SelectedValue And c.RC = ddlRCNew.SelectedValue
            If q.Count > 0 Then
                q.First.Portalid = PortalId
                q.First.FiscalYear = ddlFiscalYear.SelectedValue
                q.First.Account = ddlAccountNew.SelectedValue
                q.First.RC = ddlRCNew.SelectedValue
                q.First.P1 = tbP1new.Text
                q.First.P2 = tbP2new.Text
                q.First.P3 = tbP3new.Text
                q.First.P4 = tbP4new.Text
                q.First.P5 = tbP5new.Text
                q.First.P6 = tbP6new.Text
                q.First.P7 = tbP7new.Text
                q.First.P8 = tbP8new.Text
                q.First.P9 = tbP9new.Text
                q.First.P10 = tbP10new.Text
                q.First.P11 = tbP11new.Text
                q.First.P12 = tbP12new.Text
                q.First.Changed = True
                q.First.LastUpdated = Now
                d.SubmitChanges()
                GridView1.DataBind()
                btnCancelInsert_Click(Me, Nothing)


            Else
                'Existing Budget no longer exists... Insert the new row
                btnInsertRow_Click(Me, Nothing)
               


            End If
        End Sub

        Protected Sub btnAddTo_Click(sender As Object, e As EventArgs) Handles btnAddTo.Click
            Dim q = From c In d.AP_Budget_Summaries Where c.Portalid = PortalId And c.FiscalYear = ddlFiscalYear.SelectedValue And c.Account = ddlAccountNew.SelectedValue And c.RC = ddlRCNew.SelectedValue
            If q.Count > 0 Then
                q.First.Portalid = PortalId
                q.First.FiscalYear = ddlFiscalYear.SelectedValue
                q.First.Account = ddlAccountNew.SelectedValue
                q.First.RC = ddlRCNew.SelectedValue
                q.First.P1 += tbP1new.Text
                q.First.P2 += tbP2new.Text
                q.First.P3 += tbP3new.Text
                q.First.P4 += tbP4new.Text
                q.First.P5 += tbP5new.Text
                q.First.P6 += tbP6new.Text
                q.First.P7 += tbP7new.Text
                q.First.P8 += tbP8new.Text
                q.First.P9 += tbP9new.Text
                q.First.P10 += tbP10new.Text
                q.First.P11 += tbP11new.Text
                q.First.P12 += tbP12new.Text
                q.First.Changed = True
                q.First.LastUpdated = Now
                d.SubmitChanges()
                GridView1.DataBind()
                btnCancelInsert_Click(Me, Nothing)


            Else
                'Existing Budget no longer exists... Insert the new row
                btnInsertRow_Click(Me, Nothing)
             


            End If
        End Sub

        Protected Sub ddlRC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRC.SelectedIndexChanged



            Dim RCs = From c In d.AP_StaffBroker_CostCenters Where c.PortalId = PortalId And (c.CostCentreCode = ddlRC.SelectedValue Or ddlRC.SelectedValue = "All" Or (ddlRC.SelectedValue = "AllStaff" And c.Type = 1) Or (ddlRC.SelectedValue = "AllNonStaff" And c.Type <> 1))
                  Select c.CostCentreCode, Name = c.CostCentreCode & " (" & c.CostCentreName & ")" Order By CostCentreCode

            ddlRCNew.DataSource = RCs
            ddlRCNew.DataBind()
        End Sub

        Protected Sub ddlAC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAC.SelectedIndexChanged
            Dim Accs = From c In d.AP_StaffBroker_AccountCodes Where c.PortalId = PortalId And (ddlAC.SelectedValue = "All" Or c.AccountCode = ddlAC.SelectedValue Or ((ddlAC.SelectedValue = "3" Or ddlAC.SelectedValue = "IE") And c.AccountCodeType = 3) Or ((ddlAC.SelectedValue = "4" Or ddlAC.SelectedValue = "IE") And c.AccountCodeType = 4))
                  Select c.AccountCode, Name = c.AccountCode & " (" & c.AccountCodeName & ")" Order By AccountCode

            ddlAccountNew.DataSource = Accs
            ddlAccountNew.DataBind()
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

            Dim filename As String = "Budget.xls"
           
            File.Copy(Server.MapPath("/DesktopModules/AgapeConnect/BudgetManager/Budget.xls"), PortalSettings.HomeDirectoryMapPath & filename, True)



            Dim connStr As String = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & PortalSettings.HomeDirectoryMapPath & filename & "';Extended Properties='Excel 8.0;HDR=NO;'"
            Dim MyConnection As OleDbConnection
            MyConnection = New OleDbConnection(connStr)

            MyConnection.Open()

            'Dim sql = ""
            Dim MyCommand As New OleDbCommand()
            MyCommand.Connection = MyConnection


            Try

                'Clear the form
                '  Dim sql2 = "Update [Budget$A2:P99] Set F1='', F2='', F3='', F4='', F5='',F6='', F7='', F8='', F10='', F11='', F12='', F13='', F14='', F16='' ;"
                ' MyCommand.CommandText = sql2
                'MyCommand.ExecuteNonQuery()

                Dim sql2 = "Update [Budget$R2:R2] Set F1=@Filter"
                MyCommand.Parameters.AddWithValue("@Filter", "Fiscal Year: " & ddlFiscalYear.SelectedValue & "; R/C: " & ddlRC.SelectedItem.Text & "; A/C: " & ddlAC.SelectedItem.Text & ";")

                MyCommand.CommandText = sql2
                MyCommand.ExecuteNonQuery()
                MyCommand.Parameters.Clear()
                'Get the Current Selection
                Dim q = From c In d.AP_Budget_Summaries Where c.Portalid = PortalId And c.FiscalYear = CInt(ddlFiscalYear.SelectedValue) And (c.RC = ddlRC.SelectedValue Or ddlRC.SelectedValue = "All" Or (ddlRC.SelectedValue = "AllStaff" And c.AP_StaffBroker_CostCenter.Type = 1) Or (ddlRC.SelectedValue = "AllNonStaff" And c.AP_StaffBroker_CostCenter.Type <> 1)) And (ddlAC.SelectedValue = "All" Or c.Account = ddlAC.SelectedValue Or ((ddlAC.SelectedValue = "3" Or ddlAC.SelectedValue = "IE") And c.AP_StaffBroker_AccountCode.AccountCodeType = 3) Or ((ddlAC.SelectedValue = "4" Or ddlAC.SelectedValue = "IE") And c.AP_StaffBroker_AccountCode.AccountCodeType = 4))
                Dim i As Integer = 2


                For Each row In q
                    Dim sql = "Update[Budget$A" & i & ":P" & i & "] set F1=@Account, F2=@RC, "
                    For j = 1 To 12
                        sql &= "F" & (j + 2) & "=@P" & j & ", "

                    Next
                    sql &= "F16=@Notes;"
                    MyCommand.Parameters.AddWithValue("@Account", row.Account)
                    MyCommand.Parameters.AddWithValue("@RC", row.Account)
                    MyCommand.Parameters.AddWithValue("@P1", row.P1)
                    MyCommand.Parameters.AddWithValue("@P2", row.P2)
                    MyCommand.Parameters.AddWithValue("@P3", row.P3)
                    MyCommand.Parameters.AddWithValue("@P4", row.P4)
                    MyCommand.Parameters.AddWithValue("@P5", row.P5)
                    MyCommand.Parameters.AddWithValue("@P6", row.P6)
                    MyCommand.Parameters.AddWithValue("@P7", row.P7)
                    MyCommand.Parameters.AddWithValue("@P8", row.P8)
                    MyCommand.Parameters.AddWithValue("@P9", row.P9)
                    MyCommand.Parameters.AddWithValue("@P10", row.P10)
                    MyCommand.Parameters.AddWithValue("@P11", row.P11)
                    MyCommand.Parameters.AddWithValue("@P12", row.P12)
                    If row.ErrorMessage Is Nothing Then
                        MyCommand.Parameters.AddWithValue("@Notes", "")
                    Else
                        MyCommand.Parameters.AddWithValue("@Notes", row.ErrorMessage)
                    End If



                        MyCommand.CommandText = sql






                        MyCommand.ExecuteNonQuery()
                        MyCommand.Parameters.Clear()
                        i += 1

                Next

               
              




                MyConnection.Close()
                Dim attachment As String = "attachment; filename=Budget-" & ddlFiscalYear.SelectedValue & ".xls"

                HttpContext.Current.Response.Clear()
                HttpContext.Current.Response.ClearHeaders()
                HttpContext.Current.Response.ClearContent()
                HttpContext.Current.Response.AddHeader("content-disposition", attachment)
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
                HttpContext.Current.Response.AddHeader("Pragma", "public")
                HttpContext.Current.Response.WriteFile(PortalSettings.HomeDirectoryMapPath & filename)
                HttpContext.Current.Response.End()


            Catch ex As Exception
                StaffBrokerFunctions.EventLog("Budget", "Could Not export budget to excel: " & ex.ToString, UserId)
                MyConnection.Close()
                ' File.Delete(PortalSettings.HomeDirectoryMapPath & filename)
            Finally


            End Try




        End Sub
    End Class
End Namespace
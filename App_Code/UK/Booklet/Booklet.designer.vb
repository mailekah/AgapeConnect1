﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18010
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection

Namespace UK.Booklet
	
	<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="agapesandbox")>  _
	Partial Public Class BookletDataContext
		Inherits System.Data.Linq.DataContext
		
		Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
		
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub InsertAgape_Main_BookletImage(instance As Agape_Main_BookletImage)
    End Sub
    Partial Private Sub UpdateAgape_Main_BookletImage(instance As Agape_Main_BookletImage)
    End Sub
    Partial Private Sub DeleteAgape_Main_BookletImage(instance As Agape_Main_BookletImage)
    End Sub
    Partial Private Sub InsertAgape_Main_Booklet(instance As Agape_Main_Booklet)
    End Sub
    Partial Private Sub UpdateAgape_Main_Booklet(instance As Agape_Main_Booklet)
    End Sub
    Partial Private Sub DeleteAgape_Main_Booklet(instance As Agape_Main_Booklet)
    End Sub
    #End Region
		
		Public Sub New()
			MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As String)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As System.Data.IDbConnection)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public ReadOnly Property Agape_Main_BookletImages() As System.Data.Linq.Table(Of Agape_Main_BookletImage)
			Get
				Return Me.GetTable(Of Agape_Main_BookletImage)
			End Get
		End Property
		
		Public ReadOnly Property Agape_Main_Booklets() As System.Data.Linq.Table(Of Agape_Main_Booklet)
			Get
				Return Me.GetTable(Of Agape_Main_Booklet)
			End Get
		End Property
		
		<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.Agape_Main_Booklet_ReOrder")>  _
		Public Function Agape_Main_Booklet_ReOrder(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="ModuleId", DbType:="Int")> ByVal moduleId As System.Nullable(Of Integer)) As Integer
			Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), moduleId)
			Return CType(result.ReturnValue,Integer)
		End Function
		
		<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.Agape_Main_Booklet_Demote")>  _
		Public Function Agape_Main_Booklet_Demote(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="BookletImage", DbType:="Int")> ByVal bookletImage As System.Nullable(Of Integer)) As Integer
			Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), bookletImage)
			Return CType(result.ReturnValue,Integer)
		End Function
		
		<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.Agape_Main_Booklet_Promote")>  _
		Public Function Agape_Main_Booklet_Promote(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="BookletImage", DbType:="Int")> ByVal bookletImage As System.Nullable(Of Integer)) As Integer
			Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), bookletImage)
			Return CType(result.ReturnValue,Integer)
		End Function
		
		<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.Agape_Main_Booklet_AddPage")>  _
		Public Function Agape_Main_Booklet_AddPage(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="NewImage", DbType:="Image")> ByVal newImage As System.Data.Linq.Binary, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="ModuleId", DbType:="Int")> ByVal moduleId As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Aspect", DbType:="Float")> ByVal aspect As System.Nullable(Of Double)) As Integer
			Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), newImage, moduleId, aspect)
			Return CType(result.ReturnValue,Integer)
		End Function
		
		<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.Agape_Main_Booklet_GetAdd")>  _
		Public Function Agape_Main_Booklet_GetAdd(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="ModuleId", DbType:="Int")> ByVal moduleId As System.Nullable(Of Integer)) As ISingleResult(Of Agape_Main_Booklet_GetAddResult)
			Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), moduleId)
			Return CType(result.ReturnValue,ISingleResult(Of Agape_Main_Booklet_GetAddResult))
		End Function
	End Class
	
	<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Agape_Main_BookletImage")>  _
	Partial Public Class Agape_Main_BookletImage
		Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
		
		Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
		
		Private _BookletImage As Integer
		
		Private _ModuleId As System.Nullable(Of Integer)
		
		Private _ViewOrder As System.Nullable(Of Byte)
		
		Private _PageImage As System.Data.Linq.Binary
		
		Private _BookletId As System.Nullable(Of Integer)
		
		Private _Agape_Main_Booklet As EntityRef(Of Agape_Main_Booklet)
		
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnBookletImageChanging(value As Integer)
    End Sub
    Partial Private Sub OnBookletImageChanged()
    End Sub
    Partial Private Sub OnModuleIdChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnModuleIdChanged()
    End Sub
    Partial Private Sub OnViewOrderChanging(value As System.Nullable(Of Byte))
    End Sub
    Partial Private Sub OnViewOrderChanged()
    End Sub
    Partial Private Sub OnPageImageChanging(value As System.Data.Linq.Binary)
    End Sub
    Partial Private Sub OnPageImageChanged()
    End Sub
    Partial Private Sub OnBookletIdChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnBookletIdChanged()
    End Sub
    #End Region
		
		Public Sub New()
			MyBase.New
			Me._Agape_Main_Booklet = CType(Nothing, EntityRef(Of Agape_Main_Booklet))
			OnCreated
		End Sub
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_BookletImage", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
		Public Property BookletImage() As Integer
			Get
				Return Me._BookletImage
			End Get
			Set
				If ((Me._BookletImage = value)  _
							= false) Then
					Me.OnBookletImageChanging(value)
					Me.SendPropertyChanging
					Me._BookletImage = value
					Me.SendPropertyChanged("BookletImage")
					Me.OnBookletImageChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ModuleId", DbType:="Int")>  _
		Public Property ModuleId() As System.Nullable(Of Integer)
			Get
				Return Me._ModuleId
			End Get
			Set
				If (Me._ModuleId.Equals(value) = false) Then
					Me.OnModuleIdChanging(value)
					Me.SendPropertyChanging
					Me._ModuleId = value
					Me.SendPropertyChanged("ModuleId")
					Me.OnModuleIdChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ViewOrder", DbType:="TinyInt")>  _
		Public Property ViewOrder() As System.Nullable(Of Byte)
			Get
				Return Me._ViewOrder
			End Get
			Set
				If (Me._ViewOrder.Equals(value) = false) Then
					Me.OnViewOrderChanging(value)
					Me.SendPropertyChanging
					Me._ViewOrder = value
					Me.SendPropertyChanged("ViewOrder")
					Me.OnViewOrderChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PageImage", DbType:="Image", CanBeNull:=true, UpdateCheck:=UpdateCheck.Never)>  _
		Public Property PageImage() As System.Data.Linq.Binary
			Get
				Return Me._PageImage
			End Get
			Set
				If (Object.Equals(Me._PageImage, value) = false) Then
					Me.OnPageImageChanging(value)
					Me.SendPropertyChanging
					Me._PageImage = value
					Me.SendPropertyChanged("PageImage")
					Me.OnPageImageChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_BookletId", DbType:="Int")>  _
		Public Property BookletId() As System.Nullable(Of Integer)
			Get
				Return Me._BookletId
			End Get
			Set
				If (Me._BookletId.Equals(value) = false) Then
					If Me._Agape_Main_Booklet.HasLoadedOrAssignedValue Then
						Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
					End If
					Me.OnBookletIdChanging(value)
					Me.SendPropertyChanging
					Me._BookletId = value
					Me.SendPropertyChanged("BookletId")
					Me.OnBookletIdChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="Agape_Main_Booklet_Agape_Main_BookletImage", Storage:="_Agape_Main_Booklet", ThisKey:="BookletId", OtherKey:="BookletId", IsForeignKey:=true)>  _
		Public Property Agape_Main_Booklet() As Agape_Main_Booklet
			Get
				Return Me._Agape_Main_Booklet.Entity
			End Get
			Set
				Dim previousValue As Agape_Main_Booklet = Me._Agape_Main_Booklet.Entity
				If ((Object.Equals(previousValue, value) = false)  _
							OrElse (Me._Agape_Main_Booklet.HasLoadedOrAssignedValue = false)) Then
					Me.SendPropertyChanging
					If ((previousValue Is Nothing)  _
								= false) Then
						Me._Agape_Main_Booklet.Entity = Nothing
						previousValue.Agape_Main_BookletImages.Remove(Me)
					End If
					Me._Agape_Main_Booklet.Entity = value
					If ((value Is Nothing)  _
								= false) Then
						value.Agape_Main_BookletImages.Add(Me)
						Me._BookletId = value.BookletId
					Else
						Me._BookletId = CType(Nothing, Nullable(Of Integer))
					End If
					Me.SendPropertyChanged("Agape_Main_Booklet")
				End If
			End Set
		End Property
		
		Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
		
		Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
		
		Protected Overridable Sub SendPropertyChanging()
			If ((Me.PropertyChangingEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
			End If
		End Sub
		
		Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
			If ((Me.PropertyChangedEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
			End If
		End Sub
	End Class
	
	<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Agape_Main_Booklet")>  _
	Partial Public Class Agape_Main_Booklet
		Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
		
		Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
		
		Private _BookletId As Integer
		
		Private _ModuleId As System.Nullable(Of Integer)
		
		Private _Width As System.Nullable(Of Short)
		
		Private _Aspect As System.Nullable(Of Double)
		
		Private _PageCount As System.Nullable(Of Byte)
		
		Private _Agape_Main_BookletImages As EntitySet(Of Agape_Main_BookletImage)
		
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnBookletIdChanging(value As Integer)
    End Sub
    Partial Private Sub OnBookletIdChanged()
    End Sub
    Partial Private Sub OnModuleIdChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnModuleIdChanged()
    End Sub
    Partial Private Sub OnWidthChanging(value As System.Nullable(Of Short))
    End Sub
    Partial Private Sub OnWidthChanged()
    End Sub
    Partial Private Sub OnAspectChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub OnAspectChanged()
    End Sub
    Partial Private Sub OnPageCountChanging(value As System.Nullable(Of Byte))
    End Sub
    Partial Private Sub OnPageCountChanged()
    End Sub
    #End Region
		
		Public Sub New()
			MyBase.New
			Me._Agape_Main_BookletImages = New EntitySet(Of Agape_Main_BookletImage)(AddressOf Me.attach_Agape_Main_BookletImages, AddressOf Me.detach_Agape_Main_BookletImages)
			OnCreated
		End Sub
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_BookletId", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
		Public Property BookletId() As Integer
			Get
				Return Me._BookletId
			End Get
			Set
				If ((Me._BookletId = value)  _
							= false) Then
					Me.OnBookletIdChanging(value)
					Me.SendPropertyChanging
					Me._BookletId = value
					Me.SendPropertyChanged("BookletId")
					Me.OnBookletIdChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ModuleId", DbType:="Int")>  _
		Public Property ModuleId() As System.Nullable(Of Integer)
			Get
				Return Me._ModuleId
			End Get
			Set
				If (Me._ModuleId.Equals(value) = false) Then
					Me.OnModuleIdChanging(value)
					Me.SendPropertyChanging
					Me._ModuleId = value
					Me.SendPropertyChanged("ModuleId")
					Me.OnModuleIdChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Width", DbType:="SmallInt")>  _
		Public Property Width() As System.Nullable(Of Short)
			Get
				Return Me._Width
			End Get
			Set
				If (Me._Width.Equals(value) = false) Then
					Me.OnWidthChanging(value)
					Me.SendPropertyChanging
					Me._Width = value
					Me.SendPropertyChanged("Width")
					Me.OnWidthChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Aspect", DbType:="Float")>  _
		Public Property Aspect() As System.Nullable(Of Double)
			Get
				Return Me._Aspect
			End Get
			Set
				If (Me._Aspect.Equals(value) = false) Then
					Me.OnAspectChanging(value)
					Me.SendPropertyChanging
					Me._Aspect = value
					Me.SendPropertyChanged("Aspect")
					Me.OnAspectChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PageCount", DbType:="TinyInt")>  _
		Public Property PageCount() As System.Nullable(Of Byte)
			Get
				Return Me._PageCount
			End Get
			Set
				If (Me._PageCount.Equals(value) = false) Then
					Me.OnPageCountChanging(value)
					Me.SendPropertyChanging
					Me._PageCount = value
					Me.SendPropertyChanged("PageCount")
					Me.OnPageCountChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="Agape_Main_Booklet_Agape_Main_BookletImage", Storage:="_Agape_Main_BookletImages", ThisKey:="BookletId", OtherKey:="BookletId")>  _
		Public Property Agape_Main_BookletImages() As EntitySet(Of Agape_Main_BookletImage)
			Get
				Return Me._Agape_Main_BookletImages
			End Get
			Set
				Me._Agape_Main_BookletImages.Assign(value)
			End Set
		End Property
		
		Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
		
		Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
		
		Protected Overridable Sub SendPropertyChanging()
			If ((Me.PropertyChangingEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
			End If
		End Sub
		
		Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
			If ((Me.PropertyChangedEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
			End If
		End Sub
		
		Private Sub attach_Agape_Main_BookletImages(ByVal entity As Agape_Main_BookletImage)
			Me.SendPropertyChanging
			entity.Agape_Main_Booklet = Me
		End Sub
		
		Private Sub detach_Agape_Main_BookletImages(ByVal entity As Agape_Main_BookletImage)
			Me.SendPropertyChanging
			entity.Agape_Main_Booklet = Nothing
		End Sub
	End Class
	
	Partial Public Class Agape_Main_Booklet_GetAddResult
		
		Private _BookletId As Integer
		
		Private _ModuleId As System.Nullable(Of Integer)
		
		Private _Width As System.Nullable(Of Short)
		
		Private _Aspect As System.Nullable(Of Double)
		
		Private _PageCount As System.Nullable(Of Byte)
		
		Public Sub New()
			MyBase.New
		End Sub
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_BookletId", DbType:="Int NOT NULL")>  _
		Public Property BookletId() As Integer
			Get
				Return Me._BookletId
			End Get
			Set
				If ((Me._BookletId = value)  _
							= false) Then
					Me._BookletId = value
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ModuleId", DbType:="Int")>  _
		Public Property ModuleId() As System.Nullable(Of Integer)
			Get
				Return Me._ModuleId
			End Get
			Set
				If (Me._ModuleId.Equals(value) = false) Then
					Me._ModuleId = value
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Width", DbType:="SmallInt")>  _
		Public Property Width() As System.Nullable(Of Short)
			Get
				Return Me._Width
			End Get
			Set
				If (Me._Width.Equals(value) = false) Then
					Me._Width = value
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Aspect", DbType:="Float")>  _
		Public Property Aspect() As System.Nullable(Of Double)
			Get
				Return Me._Aspect
			End Get
			Set
				If (Me._Aspect.Equals(value) = false) Then
					Me._Aspect = value
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PageCount", DbType:="TinyInt")>  _
		Public Property PageCount() As System.Nullable(Of Byte)
			Get
				Return Me._PageCount
			End Get
			Set
				If (Me._PageCount.Equals(value) = false) Then
					Me._PageCount = value
				End If
			End Set
		End Property
	End Class
End Namespace

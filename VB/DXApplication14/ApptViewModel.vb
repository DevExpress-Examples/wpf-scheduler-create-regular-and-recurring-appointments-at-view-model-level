Imports DevExpress.Mvvm
Imports System

Namespace DXApplication14
	Public Class ApptViewModel
		Inherits BindableBase

		Public Property Subject() As String
			Get
				Return GetValue(Of String)()
			End Get
			Set(ByVal value As String)
				SetValue(value)
			End Set
		End Property
		Public Property Start() As DateTime
			Get
				Return GetValue(Of DateTime)()
			End Get
			Set(ByVal value As DateTime)
				SetValue(value)
			End Set
		End Property
		Public Property [End]() As DateTime
			Get
				Return GetValue(Of DateTime)()
			End Get
			Set(ByVal value As DateTime)
				SetValue(value)
			End Set
		End Property
		Public Property Description() As String
			Get
				Return GetValue(Of String)()
			End Get
			Set(ByVal value As String)
				SetValue(value)
			End Set
		End Property
		Public Property Type() As Integer
			Get
				Return GetValue(Of Integer)()
			End Get
			Set(ByVal value As Integer)
				SetValue(value)
			End Set
		End Property
		Public Property RecurrenceInfo() As String
			Get
				Return GetValue(Of String)()
			End Get
			Set(ByVal value As String)
				SetValue(value)
			End Set
		End Property
	End Class
End Namespace

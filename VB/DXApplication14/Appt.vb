Imports DevExpress.Mvvm
Imports System

Namespace DXApplication14
	Public Class Appt
		Inherits BindableBase


		Protected _Subject As String
		Public Property Subject() As String
			Get
				Return Me._Subject
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._Subject, value, "Subject")
			End Set
		End Property


		Protected _Start As DateTime
		Public Property Start() As DateTime
			Get
				Return Me._Start
			End Get
			Set(ByVal value As DateTime)
				Me.SetProperty(Me._Start, value, "Start")
			End Set
		End Property


		Protected _End As DateTime
		Public Property [End]() As DateTime
			Get
				Return Me._End
			End Get
			Set(ByVal value As DateTime)
				Me.SetProperty(Me._End, value, "End")
			End Set
		End Property

		Protected _Description As String
		Public Property Description() As String
			Get
				Return Me._Description
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._Description, value, "Description")
			End Set
		End Property


		Protected _Type As Integer
		Public Property Type() As Integer
			Get
				Return Me._Type
			End Get
			Set(ByVal value As Integer)
				Me.SetProperty(Me._Type, value, "Type")
			End Set
		End Property


		Protected _RecurrenceInfo As String
		Public Property RecurrenceInfo() As String
			Get
				Return Me._RecurrenceInfo
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._RecurrenceInfo, value, "RecurrenceInfo")
			End Set
		End Property
	End Class
End Namespace

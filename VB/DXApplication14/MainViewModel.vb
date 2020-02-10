Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpf.Scheduling
Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.ObjectModel

Namespace DXApplication14
	Public Class MainViewModel
		Inherits ViewModelBase

		Public Property Interval() As DateTimeRange
			Get
				Return GetValue(Of DateTimeRange)()
			End Get
			Set(ByVal value As DateTimeRange)
				SetValue(value)
			End Set
		End Property
		Public Property Appointments() As ObservableCollection(Of ApptViewModel)
			Get
				Return GetValue(Of ObservableCollection(Of ApptViewModel))()
			End Get
			Set(ByVal value As ObservableCollection(Of ApptViewModel))
				SetValue(value)
			End Set
		End Property
		Public Property SelectedAppointments() As ObservableCollection(Of ApptViewModel)
			Get
				Return GetValue(Of ObservableCollection(Of ApptViewModel))()
			End Get
			Set(ByVal value As ObservableCollection(Of ApptViewModel))
				SetValue(value)
			End Set
		End Property
		Public Sub New()
			Appointments = New ObservableCollection(Of ApptViewModel)()
			SelectedAppointments = New ObservableCollection(Of ApptViewModel)()
		End Sub
		Protected Function CreateAppt(ByVal subj As String, ByVal start As DateTime, ByVal [end] As DateTime, ByVal description As String) As ApptViewModel
			Dim apptViewModel As New ApptViewModel() With {
				.Subject = subj,
				.Start = start,
				.End = [end],
				.Description = "[add description]"
			}
			Return apptViewModel
		End Function

		<Command>
		Public Sub AddAppt(Optional ByVal recurrent As Boolean = False)
			Dim appt = CreateAppt($"New Appt #{Appointments.Count}", Interval.Start, Interval.End, "[add description]")

			If recurrent Then
				appt.Type = CInt(Math.Truncate(AppointmentType.Pattern))
				appt.RecurrenceInfo = RecurrenceBuilder.Daily(Interval.Start, 10).Build().ToXml()
			Else
				appt.Type = CInt(Math.Truncate(AppointmentType.Normal))
			End If

			Me.Appointments.Add(appt)
			Me.SelectedAppointments.Clear()
			Me.SelectedAppointments.Add(appt)
		End Sub
	End Class
End Namespace

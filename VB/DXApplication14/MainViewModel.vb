Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Xpf.Scheduling
Imports DevExpress.XtraScheduler
Imports System.Collections.ObjectModel

Namespace DXApplication14
	Public Class MainViewModel
		Public Overridable ReadOnly Property SchedulerService() As ISchedulerService
			Get
				Return Me.GetService(Of ISchedulerService)()
			End Get
		End Property
		Public Overridable Property SelectedInterval() As DateTimeRange

		Public Overridable ReadOnly Property AppointmentItems() As New ObservableCollection(Of Appt)()

		Public Overridable Property OpenWindow() As Boolean = True

		Public ReadOnly Property SelectedAppointments() As New ObservableCollection(Of Appt)()

		Protected Function CreateAppt() As Appt
			Return New Appt() With {
				.Subject = "New Appt #" & AppointmentItems.Count,
				.Start = SelectedInterval.Start,
				.End = SelectedInterval.End,
				.Description = "[add description]"
			}
		End Function

		Public Sub AddAppt(Optional ByVal recurrent As Boolean = False)
			Dim appt = CreateAppt()
			appt.Type = CInt(Math.Truncate(If(recurrent, AppointmentType.Pattern, AppointmentType.Normal)))
			appt.RecurrenceInfo = If(recurrent, RecurrenceBuilder.Daily(SelectedInterval.Start, 10).Build().ToXml(), String.Empty)
			Me.AppointmentItems.Add(appt)
			Me.SelectedAppointments.Clear()
			Me.SelectedAppointments.Add(appt)
			If SchedulerService IsNot Nothing AndAlso OpenWindow Then
				SchedulerService.ShowEditAppointmentWindow()
			End If
		End Sub
	End Class
End Namespace

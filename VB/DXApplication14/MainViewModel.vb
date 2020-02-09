Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Scheduling
Imports DevExpress.XtraScheduler
Imports System.Collections.ObjectModel

Namespace DXApplication14
	Public Class MainViewModel
		Public Overridable ReadOnly Property SchedulerService() As ISchedulerService
			Get
				Return Nothing
			End Get
		End Property
		Public Overridable Property SelectedInterval() As DateTimeRange

		Protected _AppointmentItems As ObservableCollection(Of Appt)
		Public ReadOnly Property AppointmentItems() As ObservableCollection(Of Appt)
			Get
				If Me._AppointmentItems Is Nothing Then
					Me._AppointmentItems = New ObservableCollection(Of Appt)()
				End If

				Return Me._AppointmentItems
			End Get
		End Property

		Public Overridable Property OpenWindow() As Boolean = True

		Protected _SelectedAppointments As ObservableCollection(Of Appt)
		Public ReadOnly Property SelectedAppointments() As ObservableCollection(Of Appt)
			Get
				If Me._SelectedAppointments Is Nothing Then
					Me._SelectedAppointments = New ObservableCollection(Of Appt)()
				End If

				Return Me._SelectedAppointments
			End Get
		End Property

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

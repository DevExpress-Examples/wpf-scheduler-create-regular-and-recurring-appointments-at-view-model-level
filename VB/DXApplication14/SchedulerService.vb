Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Scheduling

Namespace DXApplication14
	Public Interface ISchedulerService
		Sub ShowEditAppointmentWindow()
	End Interface
	Public Class SchedulerService
		Inherits ServiceBase
		Implements ISchedulerService

		Public Sub ShowEditAppointmentWindow() Implements ISchedulerService.ShowEditAppointmentWindow
			Dim scheduler = TryCast(Me.AssociatedObject, SchedulerControl)
			If scheduler IsNot Nothing Then
				scheduler.Commands.ShowAppointmentWindowCommand.Execute(Nothing)
			End If
		End Sub
	End Class
End Namespace

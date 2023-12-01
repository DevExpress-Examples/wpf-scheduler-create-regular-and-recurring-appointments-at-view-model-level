Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpf.Scheduling
Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.ObjectModel

Namespace DXApplication14

    Public Class MainViewModel
        Inherits DevExpress.Mvvm.ViewModelBase

        Public Property Interval As DateTimeRange
            Get
                Return GetValue(Of DevExpress.Mvvm.DateTimeRange)()
            End Get

            Set(ByVal value As DateTimeRange)
                SetValue(value)
            End Set
        End Property

        Public Property Appointments As ObservableCollection(Of DXApplication14.ApptViewModel)
            Get
                Return GetValue(Of System.Collections.ObjectModel.ObservableCollection(Of DXApplication14.ApptViewModel))()
            End Get

            Set(ByVal value As ObservableCollection(Of DXApplication14.ApptViewModel))
                SetValue(value)
            End Set
        End Property

        Public Property SelectedAppointments As ObservableCollection(Of DXApplication14.ApptViewModel)
            Get
                Return GetValue(Of System.Collections.ObjectModel.ObservableCollection(Of DXApplication14.ApptViewModel))()
            End Get

            Set(ByVal value As ObservableCollection(Of DXApplication14.ApptViewModel))
                SetValue(value)
            End Set
        End Property

        Public Sub New()
            Me.Appointments = New System.Collections.ObjectModel.ObservableCollection(Of DXApplication14.ApptViewModel)()
            Me.SelectedAppointments = New System.Collections.ObjectModel.ObservableCollection(Of DXApplication14.ApptViewModel)()
        End Sub

        Protected Function CreateAppt(ByVal subj As String, ByVal start As System.DateTime, ByVal [end] As System.DateTime, ByVal description As String) As ApptViewModel
            Dim apptViewModel As DXApplication14.ApptViewModel = New DXApplication14.ApptViewModel() With {.Subject = subj, .Start = start, .[End] = [end], .Description = "[add description]"}
            Return apptViewModel
        End Function

        <DevExpress.Mvvm.DataAnnotations.CommandAttribute>
        Public Sub AddAppt(ByVal Optional recurrent As Boolean = False)
            Dim appt = Me.CreateAppt($"New Appt #{Me.Appointments.Count}", Me.Interval.Start, Me.Interval.[End], "[add description]")
            If recurrent Then
                appt.Type = CInt(DevExpress.XtraScheduler.AppointmentType.Pattern)
                appt.RecurrenceInfo = DevExpress.Xpf.Scheduling.RecurrenceBuilder.Daily(CDate((Me.Interval.Start)), CInt((10))).Build().ToXml()
            Else
                appt.Type = CInt(DevExpress.XtraScheduler.AppointmentType.Normal)
            End If

            Me.Appointments.Add(appt)
            Me.SelectedAppointments.Clear()
            Me.SelectedAppointments.Add(appt)
        End Sub
    End Class
End Namespace

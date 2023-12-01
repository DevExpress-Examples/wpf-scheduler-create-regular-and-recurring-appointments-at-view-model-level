<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/238217751/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T859145)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Scheduler - Create Regular and Recurring Appointments at the View Model Level

This example defines View Model commands that add new regular and recurring appointments to the **Scheduler Control**.

## Implementation Details

> [!NOTE]
> Your data source type should implement the [INotifyCollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-8.0) interface (for example, [ObservableCollection\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-8.0)). In this case, the **Scheduler Control** receives notifications about its changes. 

### Create a New Appointment

1. Create a new data item instance.
2. Define item properties.
3. Add this item to your source.

In this example, the [SchedulerControl.SelectedInterval](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.SelectedInterval) property is bound to the **Interval** View Model property. Its values define **Start** and **End** properties of the new data item:

```cs
protected ApptViewModel CreateAppt(string subj, DateTime start, DateTime end, string description) {
    ApptViewModel apptViewModel = new ApptViewModel() {
        Subject = subj,
        Start = start,                
        End = end,
        Description = "[add description]"
    };
    return apptViewModel;
}
```

### Create a New Recurring Appointment

1. Set the item **Type** property to [Pattern](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.AppointmentType).
2. Use the [RecurrenceBuilder](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.RecurrenceBuilder) class to generate a recurrence rule.
3. Assign this rule to the **RecurrenceInfo** property to create a recurring appointment.

```cs
[Command]
public void AddAppt(bool recurrent = false) {
    var appt = CreateAppt($"New Appt #{Appointments.Count}", Interval.Start, Interval.End, "[add description]");
            
    if(recurrent) {
        appt.Type = (int)AppointmentType.Pattern;
        appt.RecurrenceInfo = RecurrenceBuilder.Daily(Interval.Start, 10).Build().ToXml();
    } else {
        appt.Type = (int)AppointmentType.Normal;
    }
            
    this.Appointments.Add(appt);
    this.SelectedAppointments.Clear();
    this.SelectedAppointments.Add(appt);
}
```

### Edit the Created Appointment

This example also illustrates how to invoke the [Appointment Window](https://docs.devexpress.com/WPF/119347/controls-and-libraries/scheduler/visual-elements/windows/appointment-window) for the newly created appointment:

1. Attach the [CompositeCommandBehavior](https://docs.devexpress.com/WPF/18124/mvvm-framework/behaviors/predefined-set/compositecommandbehavior) to the button that should create appointments.
2. Bind the first [CommandItem.Command](https://docs.devexpress.com/WPF/DevExpress.Mvvm.UI.CommandItem.Command) property to the View Model command that adds appointments.
3. Bind the second [CommandItem.Command](https://docs.devexpress.com/WPF/DevExpress.Mvvm.UI.CommandItem.Command) property to the **Scheduler Control** [ShowAppointmentWindowCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerCommands.ShowAppointmentWindowCommand).

```xaml
<dxb:BarButtonItem Content="Add a regular appointment">
    <dxmvvm:Interaction.Behaviors>
        <dxmvvm:CompositeCommandBehavior CanExecuteCondition="AnyCommandCanBeExecuted">
            <dxmvvm:CommandItem Command="{Binding AddApptCommand}"
                                CommandParameter="false" />
            <dxmvvm:CommandItem CheckCanExecute="False"
                                Command="{Binding ElementName=scheduler,
                                                  Path=Commands.ShowAppointmentWindowCommand}" />
        </dxmvvm:CompositeCommandBehavior>
    </dxmvvm:Interaction.Behaviors>
</dxb:BarButtonItem>
```

## Files to Review

* [MainWindow.xaml](./CS/DXApplication14/MainWindow.xaml)
* [MainViewModel.cs](./CS/DXApplication14/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/DXApplication14/MainViewModel.vb))

## Documentation

* [Create Regular and Recurrent Appointments at the View Model Level](https://docs.devexpress.com/WPF/401629/controls-and-libraries/scheduler/examples/How-to-create-regular-and-recurrent-appointments-at-the-view-model-level)
* [Create Recurrence in Code](https://docs.devexpress.com/WPF/119648/controls-and-libraries/scheduler/examples/how-to-create-recurrence-in-code)

## More Examples

* [WPF Scheduler - Create Recurrent Appointments in Code](https://github.com/DevExpress-Examples/wpf-scheduler-create-recurrent-appointments-in-code)

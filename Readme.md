# How To: Create Appointments In Code

This example illustrates how to add a new regular or recurrent appointment in code when the **Scheduler** is in bound mode.

> **NOTE:**
> It's essential that your data source type implements the [INotifyCollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8) (e.g., [ObservableCollection\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.8)). In this case, the **Scheduler Control** will receive notifications about its changes. 

To add a new appointment, create a new data item instance, define its properties, and add it to your source. In this example, SchedulerControl's [SelectedInterval](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.SelectedInterval) property is bound to the **SelectedInterval** property from the view model. Its values are used in the data item's **Start** and **End** properties:
```cs
protected Appt CreateAppt()
{
    return new Appt()
    {
        Subject = "New Appt #" + AppointmentItems.Count,
        Start = SelectedInterval.Start,
        End = SelectedInterval.End,
        Description = "[add description]"
    };
}
```

Set the item's **Type** property to [AppoinementType.Pattern](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.AppointmentType) and define a corresponding recurrence rule in the **RecurrenceInfo** property to create a recurrent appointment. Use [RecurrenceBuilder](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.RecurrenceBuilder) to generate this rule:


```cs
public void AddAppt(bool recurrent = false)
{
    var appt = CreateAppt();
    appt.Type = (int)(recurrent ? AppointmentType.Pattern : AppointmentType.Normal);
    appt.RecurrenceInfo = recurrent ? RecurrenceBuilder.Daily(SelectedInterval.Start, 10).Build().ToXml() : string.Empty;
    this.AppointmentItems.Add(appt);
    ...
}

```
Refer to the [How to: Create Recurrence in Code](https://docs.devexpress.com/WPF/119648/Controls-and-Libraries/Scheduler/Examples/How-to-Create-Recurrence-in-Code) article for more information about generating recurrence rules.

Refer to this article to learn more about generating recurrence rules with the help of RecurrenceBuilder: .

This example also illustrates how you can invoke EditAppointmentWindow for a newly created appointment at the view model level. This functionality is implemented with the help of a custom [Service](https://docs.devexpress.com/WPF/17414/mvvm-framework/services): 

```cs

public interface ISchedulerService
{
    void ShowEditAppointmentWindow();
}

public class SchedulerService : ServiceBase, ISchedulerService
{
    public void ShowEditAppointmentWindow()
    {
        var scheduler = this.AssociatedObject as SchedulerControl;
        if (scheduler != null)
            scheduler.Commands.ShowAppointmentWindowCommand.Execute(null);
    }
}
```

This service is attached to the target **Scheduler Control**: 

```xaml
<dxsch:SchedulerControl ...>
    <dxmvvm:Interaction.Behaviors>
        <local:SchedulerService/>
    </dxmvvm:Interaction.Behaviors>
</dxsch:SchedulerControl>
```

It is used at the view model level: 

```cs

public class MainViewModel 
{
    ...
	public virtual ISchedulerService SchedulerService { get { return null; } }
    ...
	
	public void AddAppt(bool recurrent = false)
	{
		...
		if (SchedulerService != null && OpenWindow)
			SchedulerService.ShowEditAppointmentWindow();
	}
}
```

For more information about POCO view models and custom services, refer to these help topics: 

* [POCO ViewModels](https://docs.devexpress.com/WPF/17352/mvvm-framework/viewmodels/poco-viewmodels)
* [How to create a Custom Service](https://docs.devexpress.com/WPF/16920/mvvm-framework/services/how-to-create-a-custom-service)
* [Services in POCO objects](https://docs.devexpress.com/WPF/17447/mvvm-framework/services/services-in-poco-objects)
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using System.Collections.ObjectModel;

namespace DXApplication14
{
    public class MainViewModel 
    {
        public virtual ISchedulerService SchedulerService { get { return this.GetService<ISchedulerService>(); } }
        public virtual DateTimeRange SelectedInterval { get; set; }

        public virtual ObservableCollection<Appt> AppointmentItems { get; } = new ObservableCollection<Appt>();

        public virtual bool OpenWindow { get; set; } = true;

        public ObservableCollection<Appt> SelectedAppointments { get; } = new ObservableCollection<Appt>();
        
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

        public void AddAppt(bool recurrent = false)
        {
            var appt = CreateAppt();
            appt.Type = (int)(recurrent ? AppointmentType.Pattern : AppointmentType.Normal);
            appt.RecurrenceInfo = recurrent ? RecurrenceBuilder.Daily(SelectedInterval.Start, 10).Build().ToXml() : string.Empty;
            this.AppointmentItems.Add(appt);
            this.SelectedAppointments.Clear();
            this.SelectedAppointments.Add(appt);
            if (SchedulerService != null && OpenWindow)
                SchedulerService.ShowEditAppointmentWindow();
        }
    }
}

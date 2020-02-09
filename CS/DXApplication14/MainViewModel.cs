using DevExpress.Mvvm;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using System.Collections.ObjectModel;

namespace DXApplication14
{
    public class MainViewModel 
    {
        public virtual ISchedulerService SchedulerService { get { return null; } }
        public virtual DateTimeRange SelectedInterval { get; set; }

        protected ObservableCollection<Appt> _AppointmentItems;
        public ObservableCollection<Appt> AppointmentItems
        {
            get
            {
                if (this._AppointmentItems == null)
                {
                    this._AppointmentItems = new ObservableCollection<Appt>();
                }

                return this._AppointmentItems;
            }
        }

        public virtual bool OpenWindow { get; set; } = true;

        protected ObservableCollection<Appt> _SelectedAppointments;
        public ObservableCollection<Appt> SelectedAppointments
        {
            get
            {
                if (this._SelectedAppointments == null)
                {
                    this._SelectedAppointments = new ObservableCollection<Appt>();
                }

                return this._SelectedAppointments;
            }
        }

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

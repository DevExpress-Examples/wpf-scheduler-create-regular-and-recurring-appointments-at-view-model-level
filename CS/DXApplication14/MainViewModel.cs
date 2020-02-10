using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using System;
using System.Collections.ObjectModel;

namespace DXApplication14 {
    public class MainViewModel : ViewModelBase {
        public DateTimeRange Interval {
            get { return GetValue<DateTimeRange>(); }
            set { SetValue(value); }
        }
        public ObservableCollection<ApptViewModel> Appointments {
            get { return GetValue<ObservableCollection<ApptViewModel>>(); }
            set { SetValue(value); }
        }
        public ObservableCollection<ApptViewModel> SelectedAppointments {
            get { return GetValue<ObservableCollection<ApptViewModel>>(); }
            set { SetValue(value); }
        }
        public MainViewModel() {
            Appointments = new ObservableCollection<ApptViewModel>();
            SelectedAppointments = new ObservableCollection<ApptViewModel>();
        }
        protected ApptViewModel CreateAppt(string subj, DateTime start, DateTime end, string description) {
            ApptViewModel apptViewModel = new ApptViewModel() {
                Subject = subj,
                Start = start,                
                End = end,
                Description = "[add description]"
            };
            return apptViewModel;
        }

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
    }
}

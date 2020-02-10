using DevExpress.Mvvm;
using System;

namespace DXApplication14
{
    public class ApptViewModel : BindableBase {
        public string Subject {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public DateTime Start {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
        public DateTime End {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
        public string Description {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Type {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public string RecurrenceInfo {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}

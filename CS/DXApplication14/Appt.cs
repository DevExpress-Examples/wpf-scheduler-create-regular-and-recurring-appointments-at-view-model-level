using DevExpress.Mvvm;
using System;

namespace DXApplication14
{
    public class Appt : BindableBase {


        protected string _Subject;
        public string Subject
        {
            get { return this._Subject; }
            set { this.SetProperty(ref this._Subject, value, "Subject"); }
        }


        protected DateTime _Start;
        public DateTime Start
        {
            get { return this._Start; }
            set { this.SetProperty(ref this._Start, value, "Start"); }
        }


        protected DateTime _End;
        public DateTime End
        {
            get { return this._End; }
            set { this.SetProperty(ref this._End, value, "End"); }
        }

        protected string _Description;
        public string Description
        {
            get { return this._Description; }
            set { this.SetProperty(ref this._Description, value, "Description"); }
        }


        protected int _Type;
        public int Type
        {
            get { return this._Type; }
            set { this.SetProperty(ref this._Type, value, "Type"); }
        }


        protected string _RecurrenceInfo;
        public string RecurrenceInfo
        {
            get { return this._RecurrenceInfo; }
            set { this.SetProperty(ref this._RecurrenceInfo, value, "RecurrenceInfo"); }
        }
    }
}

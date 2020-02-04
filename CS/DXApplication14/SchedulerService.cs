using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Scheduling;

namespace DXApplication14
{
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
}

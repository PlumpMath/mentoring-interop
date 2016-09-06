using System.Runtime.InteropServices;
using Lib;

namespace Task2
{
    [ComVisible(true)]
    [Guid("8E2C74B2-8B52-4C12-8FCF-23F86DE02EE5")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PowerManager : IPowerManager
    {
        public SystemBatteryState GetSystemBatteryState()
        {
            return Lib.PowerManager.GetSystemBatteryState();
        }

        public SystemPowerInformation GetSystemPowerInformation()
        {
            return Lib.PowerManager.GetSystemPowerInformation();
        }

        public long GetLastWakeTime()
        {
            return Lib.PowerManager.GetLastWakeTime();
        }

        public long GetLastSleepTime()
        {
            return Lib.PowerManager.GetLastSleepTime();
        }

        public void ReserveHibernationFile()
        {
            Lib.PowerManager.ReserveHibernationFile();
        }

        public void RemoveHibernationFile()
        {
            Lib.PowerManager.RemoveHibernationFile();
        }

        public void Sleep()
        {
            Lib.PowerManager.Sleep();
        }

        public void Hibernate()
        {
            Lib.PowerManager.Hibernate();
        }
    }
}

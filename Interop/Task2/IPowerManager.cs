using System.Runtime.InteropServices;
using Lib;

namespace Task2
{
    [ComVisible(true)]
    [Guid("69E39A4B-7106-41A6-B5CF-3A6FA0B4E6D6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IPowerManager
    {
        SystemBatteryState GetSystemBatteryState();
        SystemPowerInformation GetSystemPowerInformation();
        long GetLastWakeTime();
        long GetLastSleepTime();
        void ReserveHibernationFile();
        void RemoveHibernationFile();
        void Sleep();
        void Hibernate();
    }
}

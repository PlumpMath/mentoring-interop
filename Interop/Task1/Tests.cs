using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetSystemBatteryStateTest()
        {
            var res = PowerManager.GetSystemBatteryState();
            res.DumpFields();
        }

        [TestMethod]
        public void GetSystemPowerInformationTest()
        {
            var res = PowerManager.GetSystemPowerInformation();
            res.DumpFields();
        }

        [TestMethod]
        public void GetGetLastWakeTimeTest()
        {
            var res = PowerManager.GetLastWakeTime();
            res.DumpValue();
        }

        [TestMethod]
        public void GetGetLastSleepTimeTest()
        {
            var res = PowerManager.GetLastSleepTime();
            res.DumpValue();
        }

        [TestMethod]
        public void ReserveHibernationFileTest()
        {
            PowerManager.ReserveHibernationFile();
        }

        [TestMethod]
        public void RemoveHibernationFileTest()
        {
            PowerManager.RemoveHibernationFile();
        }

        [TestMethod]
        public void SleepTest()
        {
            PowerManager.Sleep();
        }

        [TestMethod]
        public void HibernateTest()
        {
            PowerManager.Hibernate();
        }
    }
}

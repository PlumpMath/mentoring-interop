using System;
using System.Runtime.InteropServices;

namespace Task1.Lib
{
    public static class PowerManager
    {
        public static SystemBatteryState GetSystemBatteryState()
        {
            return CallPowerInformation(InformationLevel.SystemBatteryState, Marshal.PtrToStructure<SystemBatteryState>);
        }

        public static SystemPowerInformation GetSystemPowerInformation()
        {
            return CallPowerInformation(InformationLevel.SystemPowerInformation, Marshal.PtrToStructure<SystemPowerInformation>);
        }

        public static long GetLastWakeTime()
        {
            return CallPowerInformation(InformationLevel.LastWakeTime, Marshal.ReadInt64);
        }

        public static long GetLastSleepTime()
        {
            return CallPowerInformation(InformationLevel.LastSleepTime, Marshal.ReadInt64);
        }

        public static void ReserveHibernationFile()
        {
            var buffer = Marshal.AllocCoTaskMem(sizeof(bool));
            Marshal.WriteByte(buffer, 1);
            CallPowerInformation(InformationLevel.SystemReserveHiberFile, Marshal.ReadInt64, buffer);
            Marshal.FreeCoTaskMem(buffer);
        }

        public static void RemoveHibernationFile()
        {
            var buffer = Marshal.AllocCoTaskMem(sizeof(bool));
            Marshal.WriteByte(buffer, 0);
            CallPowerInformation(InformationLevel.SystemReserveHiberFile, Marshal.ReadInt64, buffer);
            Marshal.FreeCoTaskMem(buffer);
        }

        public static void Sleep()
        {
            SetSuspendState(false, false, false);
        }

        public static void Hibernate()
        {
            SetSuspendState(true, false, false);
        }

        private const uint StatusSuccess = 0;

        [DllImport("powrprof.dll", SetLastError = true)]
        static extern uint CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            uint nInputBufferSize,
            IntPtr lpOutputBuffer,
            uint nOutputBufferSize
        );

        [DllImport("powrprof.dll", SetLastError = true)]
        static extern uint SetSuspendState(
            bool hibernate,
            bool forceCritical,
            bool disableWakeEvent
        );


        private static T CallPowerInformation<T>(int informationLevel, Func<IntPtr, T> convert)
        {
            return CallPowerInformation<T>(informationLevel, convert, (IntPtr) null);
        }

        private static T CallPowerInformation<T>(int informationLevel, Func<IntPtr, T> convert, IntPtr inputBuffer)
        {
            var status = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(T)));
            var returnValue = CallNtPowerInformation(
                informationLevel,
                inputBuffer,
                0,
                status, (uint)Marshal.SizeOf(typeof(T)));
            var result = returnValue == StatusSuccess ? convert(status) : default(T);
            Marshal.FreeCoTaskMem(status);
            return result;
        }
    }
}

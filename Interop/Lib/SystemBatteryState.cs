namespace Lib
{
    public struct SystemBatteryState
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        public bool[] Spare1;
        public double MaxCapacity;
        public double RemainingCapacity;
        public double Rate;
        public double EstimatedTime;
        public double DefaultAlert1;
        public double DefaultAlert2;
    }
}

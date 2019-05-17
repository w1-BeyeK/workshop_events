using System;

namespace AlarmLibrary
{
    public class AlarmEventArgs : EventArgs
    {
        public Alarm Alarm { get; set; }
    }
}
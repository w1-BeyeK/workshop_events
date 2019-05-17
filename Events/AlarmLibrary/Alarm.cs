using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmLibrary
{
    public class Alarm
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }

        public Alarm(string name, DateTime time)
        {
            this.Name = name;
            this.Time = time;
        }
    }
}

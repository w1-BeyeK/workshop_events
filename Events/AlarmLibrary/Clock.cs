using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmLibrary
{
    public class Clock
    {
        private readonly List<Alarm> _alarms;
        private bool _running = false;

        public Clock()
        {
            _alarms = new List<Alarm>();
        }

        public void AddAlarm(Alarm a)
        {
            _alarms.Add(a);
        }

        public async Task Start()
        {
            _running = true;
            await Task.Run(async () => await CheckAlarms());
        }

        private Task CheckAlarms()
        {
            while (!_running)
            {
                if(_alarms.Any(a => a.Time.ToString("HH:mm:ss") == DateTime.Now.ToString("HH:mm:ss")))
                {
                    
                }
                Thread.Sleep(1000);
            }
            return Task.FromResult<object>(null);
        }

        public void Stop()
        {
            _running = false;
        }
    }
}

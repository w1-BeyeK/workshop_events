using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLibrary
{
    public class ControlTower
    {
        public string Name { get; set; }
        public string Airfield { get; set; }

        public void UpdateFlights(object sender, LateArrivalEventArgs e)
        {
            Console.WriteLine("Plane {0} is {1} hours later!", e.Flight.Name, (e.Actual - e.Planned).TotalHours);
        }

    }
}

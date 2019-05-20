using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLibrary
{
    public class ControlTower
    {
        public string Name { get; set; }
        public string Airfield { get; set; }

        /// <summary>
        /// update flights method used to subscribe to flight events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateFlights(object sender, LateArrivalEventArgs e)
        {
            // Write to console (Output window)
            Console.WriteLine("Plane {0} is delayed by {1} hours!", e.Flight.Name, (e.Actual - e.Planned).TotalHours);
        }

    }
}

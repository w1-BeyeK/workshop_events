using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLibrary
{
    public class Terminal
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public List<Flight> Flights { get; }

        public Terminal()
        {
            Flights = new List<Flight>();
            this.OnFlightsUpdated += FlightsUpdated;
        }

        public event EventHandler OnFlightsUpdated;

        public void AddFlight(Flight f)
        {
            f.OnLateArrival += FlightOnLateArrival;
        }

        public void FlightOnLateArrival(object sender, LateArrivalEventArgs e)
        {
            this.OnFlightsUpdated?.Invoke(this, e);
        }

        protected void FlightsUpdated(object sender, EventArgs e)
        {
            // Custom logic
        }
    }
}

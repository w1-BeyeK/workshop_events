using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLibrary
{
    public class Terminal
    {
        // Variables
        public string Name { get; set; }
        public int Number { get; set; }

        // Flights
        public List<Flight> Flights { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Terminal()
        {
            Flights = new List<Flight>();

            // Subscribe to myself for ...
            this.OnFlightsUpdated += FlightsUpdated;
        }

        /// <summary>
        /// Default flight on updates
        /// </summary>
        public event EventHandler OnFlightsUpdated;
        
        /// <summary>
        /// On late flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FlightOnLateArrival(object sender, LateArrivalEventArgs e)
        {
            // Invoke own event
            this.OnFlightsUpdated?.Invoke(this, e);
        }

        protected void FlightsUpdated(object sender, EventArgs e)
        {
            // Custom logic
        }
    }
}

using System;

namespace FlightLibrary
{
    public class Flight
    {
        /// <summary>
        /// Variables
        /// </summary>
        public string Name { get; set; }
        public DateTime Arrival { get; set; }
        public int LandingStrip { get; set; }

        public bool IsLate { get; set; }

        /// <summary>
        /// Delegate for late arrival event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void LateArrival(object sender, LateArrivalEventArgs e);
        /// <summary>
        /// Event for late arrival
        /// </summary>
        public event LateArrival OnLateArrival;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Flight()
        {
            IsLate = false;

            // Subscribe to myself for debugging and error prevention
            this.OnLateArrival += AtLateArrival;
        }

        public override string ToString()
        {
            return string.Format("{0} | {1}", Name, Arrival);
        }

        /// <summary>
        /// Delay the plane by X hours
        /// </summary>
        /// <param name="hours"></param>
        public void Delay(int hours)
        {
            IsLate = true;

            // Set dates for event
            DateTime old = Arrival;
            Arrival = Arrival.AddHours(hours);

            // Create event args
            LateArrivalEventArgs e = new LateArrivalEventArgs
            {
                Flight = this,
                Planned = old,
                Actual = Arrival
            };

            // Invoke/trigger event
            this.OnLateArrival?.Invoke(this, e);
        }

        protected void AtLateArrival(object sender, LateArrivalEventArgs e)
        {
            // Perhaps notify passengers
        }
    }
}

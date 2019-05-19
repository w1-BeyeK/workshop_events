using System;

namespace FlightLibrary
{
    public class Flight
    {
        public string Name { get; set; }
        public DateTime Arrival { get; set; }
        public int LandingStrip { get; set; }

        public bool IsLate { get; set; }

        public delegate void LateArrival(object sender, LateArrivalEventArgs e);
        public event LateArrival OnLateArrival;

        public Flight()
        {
            IsLate = false;
            this.OnLateArrival += AtLateArrival;
        }

        public override string ToString()
        {
            return string.Format("{0} | {1}", Name, Arrival);
        }

        public void Delay(int hours)
        {
            IsLate = true;
            DateTime old = Arrival;
            Arrival = Arrival.AddHours(hours);

            LateArrivalEventArgs e = new LateArrivalEventArgs
            {
                Flight = this,
                Planned = old,
                Actual = Arrival
            };
            this.OnLateArrival(this, e);
        }

        protected void AtLateArrival(object sender, LateArrivalEventArgs e)
        {
            // Perhaps notify passengers
        }
    }
}

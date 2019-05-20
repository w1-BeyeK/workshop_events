using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLibrary
{
    public class LateArrivalEventArgs : EventArgs
    {
        // Flight object
        public Flight Flight { get; set; }

        // Planned time to arrive
        public DateTime Planned { get; set; }

        // Time the plane actually arrives
        public DateTime Actual { get; set; }
    }
}

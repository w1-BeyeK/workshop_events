using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLibrary
{
    public class LateArrivalEventArgs : EventArgs
    {
        public Flight Flight { get; set; }

        public DateTime Planned { get; set; }
        public DateTime Actual { get; set; }
    }
}

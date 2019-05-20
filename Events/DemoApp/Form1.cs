using AlarmLibrary;
using FlightLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        // Flight amount
        private readonly int amountOfFlights = 50;

        // Variables
        protected ControlTower controlTower;
        protected Terminal terminal;

        protected List<Flight> flights;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Initiate standard variables
            flights = new List<Flight>();

            controlTower = new ControlTower();
            controlTower.Name = "CT #1";
            controlTower.Airfield = "Schiphol Airport";
            terminal = new Terminal();
            terminal.Name = "Terminal East #23";
            terminal.Number = 23;
            terminal.OnFlightsUpdated += UpdateFlights;

            // Create flights
            for (int i = 1; i <= amountOfFlights; i++)
            {
                // Create flights
                Flight f = new Flight();
                f.Name = "Flight #" + i;
                f.LandingStrip = i;
                f.Arrival = DateTime.Now;

                // Subscribe to events
                f.OnLateArrival += terminal.FlightOnLateArrival;
                f.OnLateArrival += controlTower.UpdateFlights;

                // Add to clipboard
                flights.Add(f);
                lbFlights.Items.Add(f);
            }
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            // Check if item selected
            if(!(lbFlights.SelectedItem is null))
            {
                // Find first flight with same name
                Flight flight = flights.FirstOrDefault(f => f.Name == ((Flight)lbFlights.SelectedItem).Name);
                
                // Delay flight by 5 hours
                flight.Delay(5);
            }
        }

        private void UpdateFlights(object sender, EventArgs e)
        {
            // Clear items in listbox
            lbFlights.Items.Clear();
            // Fill listbox again in descending order by arrival date
            // This makes sure the last flight comes on top
            foreach(Flight f in flights.OrderByDescending(f => f.Arrival))
            {
                lbFlights.Items.Add(f);
            }
        }
    }
}

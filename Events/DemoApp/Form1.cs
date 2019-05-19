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
        private readonly int amountOfFlights = 50;

        protected ControlTower controlTower;
        protected Terminal terminal;

        protected List<Flight> flights;

        public Form1()
        {
            InitializeComponent();

            flights = new List<Flight>();

            controlTower = new ControlTower();
            controlTower.Name = "CT #1";
            controlTower.Airfield = "Schiphol Airport";
            terminal = new Terminal();
            terminal.Name = "Terminal East #23";
            terminal.Number = 23;
            terminal.OnFlightsUpdated += UpdateFlights;

            for (int i = 0; i < amountOfFlights; i++)
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
            if(!(lbFlights.SelectedItem is null))
            {
                Flight flight = flights.FirstOrDefault(f => f.Name == ((Flight)lbFlights.SelectedItem).Name);
                flight.Delay(5);
            }
        }

        private void UpdateFlights(object sender, EventArgs e)
        {
            lbFlights.Items.Clear();
            foreach(Flight f in flights.OrderByDescending(f => f.Arrival))
            {
                lbFlights.Items.Add(f);
            }
        }
    }
}

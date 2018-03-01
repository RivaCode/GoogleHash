using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Models
{
    class Data
    {
        public Data(Vehicle[] vehicles, Ride[] rides)
        {
            Vehicles = vehicles;
            Rides = rides;
        }

        public Vehicle[] Vehicles { get; }
        public Ride[] Rides { get; }
    }
}

﻿namespace Scheduler.Models
{
    public class Data
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

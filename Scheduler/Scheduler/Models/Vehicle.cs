namespace Scheduler.Models
{
    public class Vehicle
    {
        public Coordinate CurentLocation { get; set; }
        public Path CurrentVehiclePath { get; set; }

        public bool Taken { get; set; }
        public Ride CurrentRide { get; set; } 
    }
}

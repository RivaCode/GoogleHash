namespace Scheduler.Models
{
    public class Data
    {
        public Data(Vehicle[] vehicles, Ride[] rides, int steps, int bonus)
        {
            Vehicles = vehicles;
            Rides = rides;
            Steps = steps;
            Bonus = bonus;
        }

        public Vehicle[] Vehicles { get; }
        public Ride[] Rides { get; }
        public int Steps { get; }
        public int Bonus { get; }
    }
}

namespace Scheduler.Models
{
    public class Ride
    {
        public int StartStep { get; set; }
        public int EndStep { get; set; }

        public Path RidePath { get; set; }
        public bool IsTaken { get; set; }
        public bool IsAvailiable => !IsTaken;
    }
}

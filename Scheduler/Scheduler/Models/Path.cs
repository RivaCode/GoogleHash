namespace Scheduler.Models
{
    public class Path
    {
        public Coordinate StartLocation { get; set; }
        public Coordinate EndLocation { get; set; }

        public int Lenght { get; set; }
        public int Done { get; set; }
    }
}
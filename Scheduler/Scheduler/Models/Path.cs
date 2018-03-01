namespace Scheduler.Models
{
    public class Path
    {
        public Coordinate StartLocation { get;  }
        public Coordinate EndLocation { get; }

        public int Length { get; set; }
        public int StepsDone { get; set; }
        public bool IsDone => StepsDone == Length;

        public Path(Coordinate start, Coordinate end)
        {
            StartLocation = start;
            EndLocation = end;
        }
    }
}
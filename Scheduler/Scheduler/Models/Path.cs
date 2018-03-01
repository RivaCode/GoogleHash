using Scheduler.Extentions;

namespace Scheduler.Models
{
    public class Path
    {
        public Coordinate StartLocation { get;  }
        public Coordinate EndLocation { get; }

        public int Lenght { get; }
        public int StepsDone { get; set; }
        public bool IsDone => StepsDone == Lenght;

        public Path(Coordinate start, Coordinate end)
        {
            StartLocation = start;
            EndLocation = end;
            Lenght = start.PathLength(end);
        }
    }
}
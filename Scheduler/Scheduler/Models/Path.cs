using Scheduler.Extentions;
using System.Diagnostics;

namespace Scheduler.Models
{
    [DebuggerDisplay("Start:{StartLocation} -> End:{EndLocation}, Done:{IsDone}, Length:{Length}")]
    public class Path
    {
        public Coordinate StartLocation { get;  }
        public Coordinate EndLocation { get; }

        public int Length { get; }
        public int StepsDone { get; set; }
        public bool IsDone => StepsDone == Length;

        public Path(Coordinate start, Coordinate end)
        {
            StartLocation = start;
            EndLocation = end;
            Length = start.PathLength(end);
        }
    }
}
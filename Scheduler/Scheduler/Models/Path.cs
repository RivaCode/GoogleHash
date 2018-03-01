using System.Diagnostics;

namespace Scheduler.Models
{
    [DebuggerDisplay("Start:{StartLocation} -> End:{EndLocation}, Done:{Done}, Length:{Length}")]
    public class Path
    {
        public Coordinate StartLocation { get; set; }
        public Coordinate EndLocation { get; set; }

        public int Length { get; set; }
        public int Done { get; set; }
    }
}
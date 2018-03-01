using System.Diagnostics;

namespace Scheduler.Models
{
    [DebuggerDisplay("[{X},{Y}]")]
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}

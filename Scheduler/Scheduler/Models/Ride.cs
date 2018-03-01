using System.Diagnostics;

namespace Scheduler.Models
{
    [DebuggerDisplay("Step:[{StartStep},{EndStep}], Path:{RidePath}, IsTaken:{IsTaken}, IsAvailiable:{IsAvailiable}")]
    public class Ride
    {
        public int Id { get; }
        public int StartStep { get; set; }
        public int EndStep { get; set; }
        
        public Path RidePath { get; set; }
        public bool IsTaken { get; set; }
        public bool IsAvailiable => !IsTaken;

        public Ride(int id)
        {
            Id = id;
        }
    }
}

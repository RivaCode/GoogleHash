using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scheduler.Models;

namespace Scheduler
{
    public class History : IEnumerable<IEnumerable<int>>
    {
        private Dictionary<Vehicle, List<Ride>> _tracker;
        public History()
        {
            _tracker = new Dictionary<Vehicle, List<Ride>>(new VehicleComparer());
        }

        internal void Add(Vehicle v, Ride ride)
        {
            if (!_tracker.ContainsKey(v))
            {
                _tracker.Add(v, new List<Ride>());
            }
            _tracker[v].Add(ride);
        }

        private class VehicleComparer : IEqualityComparer<Vehicle>
        {
            public bool Equals(Vehicle x, Vehicle y) => x.Id == y.Id;

            public int GetHashCode(Vehicle obj) => obj.Id.GetHashCode();
        }

        public IEnumerator<IEnumerable<int>> GetEnumerator()
        {
            return _tracker.Values.Select(rides =>
            {
                var clone = rides.Select(r => r.Id).ToList();
                clone.Insert(0, rides.Capacity);

                return clone.AsEnumerable();
            }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

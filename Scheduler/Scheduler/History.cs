using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scheduler.Models;

namespace Scheduler
{
    public class History : IEnumerable<IEnumerable<int>>
    {
        private class VehicleComparer : IEqualityComparer<Vehicle>
        {
            public bool Equals(Vehicle x, Vehicle y) => x.Id == y.Id;

            public int GetHashCode(Vehicle obj) => obj.Id.GetHashCode();
        }

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

        public IEnumerator<IEnumerable<int>> GetEnumerator()
            => _tracker.Values
                .Select(
                    rides => new[] {rides.Count}.Concat(rides.Select(r => r.Id)))
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

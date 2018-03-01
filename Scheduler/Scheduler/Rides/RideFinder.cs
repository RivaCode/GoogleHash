using System;
using System.Linq;
using Scheduler.Extentions;
using Scheduler.Models;

namespace Scheduler.Rides
{
    public static class RideFinder
    {
        public static Ride FindRide(Vehicle v, Ride[] r)
        {
            var stepsToRide = r
                .Select(c => Tuple.Create(v.CurentLocation.PathLength(c.RidePath.StartLocation),c))
                .OrderBy(t => t.Item1)
                .ToList();

            return stepsToRide.First().Item2;
        }

        


        
    }

    
}
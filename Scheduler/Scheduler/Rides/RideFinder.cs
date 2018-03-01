using System;
using System.Collections.Generic;
using System.Linq;
using Scheduler.Extentions;
using Scheduler.Models;

namespace Scheduler.Rides
{
    public static class RideFinder
    {
        public static Ride FindRide(Vehicle v, Ride[] r, int currentStep)
        {
            var id =  GetOptimizeRide(r
                .Select(c => new PreVehicleRideData(v.CurentLocation.PathLength(c.RidePath.StartLocation), c.StartStep,
                    c.RidePath.Length)), currentStep);

            return r.First(c => c.Id == id);
        }

        public static int GetOptimizeRide(IEnumerable<PreVehicleRideData> data, int currentStep)
        {
            return data
                .Where(d => IsRideCanGiveBonus(d, currentStep))
                .OrderBy(d => d.WaitTime)
                .ThenBy(d => d.StepsToStart)
                .First()
                .Id;

        }

        public static Ride GetClosesRide(Vehicle v, Ride[] r)
        {
            var stepsToRide = r
                .Select(c => Tuple.Create(v.CurentLocation.PathLength(c.RidePath.StartLocation), c))
                .OrderBy(t => t.Item1)
                .ToList();

            return stepsToRide.First().Item2;
        }

        private static bool IsRideCanGiveBonus(PreVehicleRideData r, int currentStep)
        {
            var length = r.RideLenght;

            if (currentStep > r.AvailiableAt)
                length = r.RideLenght - (currentStep - r.AvailiableAt);
            
            if (length >= r.RideLenght)
                return false;

            return true;
        }
        
    }

    
}
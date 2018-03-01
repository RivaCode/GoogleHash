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
                    c.RidePath.Length)
                {
                    Id = c.Id
                }.UpdateWaitTime(currentStep)
                ).ToList(), currentStep);

            return r.First(c => c.Id == id);
        }
        
        private static int GetOptimizeRide(List<PreVehicleRideData> data, int currentStep)
        {
            var maxRideLn = data.Max(x => x.RideLenght);
            var avgRideLn = data.Average(x => x.RideLenght);

            var bonusData = data
                .Where(d => d.CanGetStartOnTimeBonus(currentStep))
                .Where(d => d.RideLenght < avgRideLn * 2.5)
                .OrderBy(d => d.WaitTime)
                .ThenBy(d => d.StepsToStart)
                .FirstOrDefault();

            if (bonusData != null)
                return bonusData.Id;
            
            var preVehicleRideDatas = data
                .Where(d => IsRideCanFinishedInTime(d, currentStep))
                .ToList();

            if (!preVehicleRideDatas.Any())
                return data.First().Id;

            return preVehicleRideDatas
                .Where(d => d.RideLenght < avgRideLn * 2.5)
                .OrderBy(d => d.WaitTime)
                .ThenBy(d => d.StepsToStart)
                .First()
                .Id;
        }

        private static bool IsRideCanFinishedInTime(PreVehicleRideData r, int currentStep)
        {
            var length = r.RideLenght;

            if (currentStep > r.AvailiableAt)
                length = r.RideLenght - (currentStep - r.AvailiableAt);
            
            if (length > r.RideLenght)
                return false;

            return true;
        }
    }

    
}
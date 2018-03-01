using Scheduler.Models;
using Scheduler.Rides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler.Simulation
{
    public class Simulation
    {
        public int StepLimit { get; set; }
        public Vehicle[] Vehicles { get; set; }

        public History History { get; set;}

        public Dictionary<int, Ride> AvailableRides { get; set; }
        public Dictionary<int, Ride> TakenRides { get; set; }

        public void Run()
        {
            for (int t = 0; t < StepLimit; t++)
            {
                foreach (var v in Vehicles)
                {
                    if (v.CurrentRide != null) continue;

                    if (AvailableRides.Count == 0) continue;

                    var takenRide = RideFinder.FindRide(v, AvailableRides.Values.ToArray(), t);

                    TakenRides.Add(takenRide.Id, takenRide);
                    AvailableRides.Remove(takenRide.Id);

                    if (takenRide != null)
                    {
                        if (takenRide.RidePath.StartLocation == v.CurentLocation) // create path for current eeide
                        {
                            History.Add(v, v.CurrentRide);
                            v.CurrentVehiclePath = new Path(
                                takenRide.RidePath.StartLocation, 
                                takenRide.RidePath.EndLocation);
                            v.Taken = true;
                            v.CurrentRide = takenRide;
                        }
                        else // create path to take ride
                        {
                            v.CurrentVehiclePath = new Path(
                                v.CurentLocation,
                                takenRide.RidePath.StartLocation);
                            v.Taken = false;
                            v.CurrentRide = takenRide;
                        }
                    }
                }

                foreach (var v in Vehicles)
                {
                    if (v.CurrentVehiclePath != null) // When no path vehicle has nothing to do
                    {
                        v.CurrentVehiclePath.StepsDone++;

                        if (v.CurrentVehiclePath.IsDone) // vehicle has reached destination
                        {
                            v.CurentLocation = v.CurrentVehiclePath.EndLocation;
                            
                            if (v.Taken) // the path was with a ride
                            {
                                //History.Add(v, v.CurrentRide);
                                v.CurrentRide = null; // push the human out
                                v.Taken = false;
                                v.CurrentVehiclePath = null; // Path ended
                            }

                            else
                            {
                                if (v.CurrentRide.StartStep < t)
                                    continue;
                                History.Add(v, v.CurrentRide);
                                v.Taken = true;
                                v.CurrentVehiclePath = new Path(v.CurentLocation, v.CurrentRide.RidePath.EndLocation);
                            }
                        }
                    }

                    if (v.CurrentRide != null && v.Taken == false) // waiting on the intersection
                    {
                        if (v.CurrentRide.StartStep < t)
                            continue;
                        History.Add(v, v.CurrentRide);
                        v.Taken = true;
                        v.CurrentVehiclePath = new Path(v.CurentLocation, v.CurrentRide.RidePath.EndLocation);
                    }
                }
            }
        }
    }
}

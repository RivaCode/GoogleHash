using System;
using System.Collections.Generic;
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
                    if (v.Taken) continue;

                    var takenRide = RideManager.FindRide(v, AvailableRides.Values);

                    TakenRides.Add(takenRide.Id, takenRide);
                    AvailableRides.Remove(takenRide.Id);

                    if (takenRide != null)
                    {
                        if (takenRide.Position == v.Position) // create path for current eeide
                        {
                            History.AddStarted(v.CurrentRide);
                            v.Path = new Path(takenRide.Start, takenRide.End);
                            v.Taken = true;
                            v.CurrentRide = takenRide;
                        }
                        else // create path to take ride
                        {
                            v.Path = new Path(takenRide.Start, takenRide.End);
                            v.Taken = false;
                            v.CurrentRide = takenRide;
                        }
                    }
                }

                foreach (var v in Vehicles)
                {
                    if (v.Path != null) // When no path vehicle has nothing to do
                    {
                        v.Path.Current++;

                        if (v.Path.Current == v.Path.Length - 1) // vehicle has reached destination
                        {
                            v.Position = v.Path.End;
                            
                            if (v.Taken) // the path was with a ride
                            {
                                History.AddFinished(v.CurrentRide);
                                v.CurrentRide = null; // push the human out
                                v.Taken = false;
                                v.Path = null; // Path ended
                            }

                            else
                            {
                                History.AddStarted(v.CurrentRide);
                                v.Taken = true;
                                v.Path = new Path(v.CurrentRide.Start, v.CurrentPath.End);
                            }
                        }
                    }
                }
            }
        }
    }
}

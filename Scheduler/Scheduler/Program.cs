using System;
using System.Linq;
using Scheduler.Extentions;

namespace Scheduler
{
    class Program
    {
        private const string EXAMPLE = "a_example.in";
        private const string SHOULD_BE_EASY = "b_should_be_easy.in";
        private const string NO_HURRY = "c_no_hurry.in";
        private const string METROPOLIS = "d_metropolis.in";
        private const string HIGH_BONUS = "e_high_bonus.in";

        static void Main(string[] args)
        {
            var data = Parser.Parse(EXAMPLE);

            var simulation = new Simulation.Simulation
            {
                AvailableRides =
                data.Rides.ToDictionary(
                    x => x.Id,
                    x => x),
                History = new History(),
                StepLimit = data.Steps,
                TakenRides = new System.Collections.Generic.Dictionary<int, Models.Ride>(),
                Vehicles = data.Vehicles
            };

            simulation.Run();
            simulation.History.Submit(EXAMPLE);
        }

        static void RunSimulation()
        {

        }
    }
}

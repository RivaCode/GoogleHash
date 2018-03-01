using System;
using System.Linq;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = Parser.Parse("a_example.in");

            var simulation = new Simulation.Simulation
            {
                AvailableRides =
                data.Rides.ToDictionary(
                    x => x.Id,
                    x => x),
                History = new History(),
                StepLimit = 10,
                TakenRides = new System.Collections.Generic.Dictionary<int, Models.Ride>(),
                Vehicles = data.Vehicles
            };

            simulation.Run();


            Console.Read();
        }

        static void RunSimulation()
        {

        }
    }
}

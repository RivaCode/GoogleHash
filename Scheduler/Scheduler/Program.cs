using System;

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
            Console.WriteLine("Hello World!");
            var data = Parser.Parse(EXAMPLE);
            Console.Read();
        }

        static void RunSimulation()
        {

        }
    }
}

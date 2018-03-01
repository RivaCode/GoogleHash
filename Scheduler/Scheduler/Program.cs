using System;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = Parser.Parse("a_example.in");
            Console.Read();
        }
    }
}

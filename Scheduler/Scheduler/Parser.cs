using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Scheduler
{
    public static class Parser
    {
        private const int R_ROWS = 0;
        private const int C_COLUMNS = 1;
        private const int F_VEHICLES = 2;
        private const int N_RIDES = 3;
        private const int B_BONUS = 4;
        private const int T_STEPS = 5;

        public static Data Read(string fileName)
        {
            return File.ReadLines(
                    Path.Combine(Directory.GetCurrentDirectory(), "inputs", fileName))
                .Take(1)
                .Select(i =>
                {
                    var row = i.Split(' ').Select(c => int.Parse(c)).ToArray();
                    var vehicles = new Vehicle[row[F_VEHICLES]];
                    var rides = new Ride[row[N_RIDES]];
                    return new Data(vehicles, rides);
                }).ToList()[0];
        }
    }
}

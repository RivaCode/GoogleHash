﻿using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using IOPath = System.IO;

namespace Scheduler
{
    public static class Parser
    {
        public static Data Parse(string fileName)
        {
            var lines = IOPath.File.ReadLines(
                IOPath.Path.Combine(IOPath.Directory.GetCurrentDirectory(), "inputs", fileName))
                .ToList();

            const int BONUS = 4;
            const int STEPS = 5;

            var firstLine = lines.Take(1).AsNumeric().First();
            var bonus = firstLine[BONUS];
            var steps = firstLine[STEPS];
            var vehicles = firstLine.ReadVehicles();
            var rides = lines.Skip(1).AsNumeric().ReadRides();

            return new Data(vehicles, rides, steps, bonus);
        }

        private static Vehicle[] ReadVehicles(this int[] firstLineInfo)
        {
            const int F_VEHICLES = 2;
            return Enumerable.Range(0, firstLineInfo[F_VEHICLES])
                .Select(i => new Vehicle(i)
                {
                    CurentLocation = new Coordinate { X = 0, Y = 0 },
                    CurrentRide = null,
                    CurrentVehiclePath = null,
                    Taken = false
                }).ToArray();
        }

        private static Ride[] ReadRides(this IEnumerable<int[]> ridesInfo)
        {
            const int ROW_START = 0;
            const int COLUMN_START = 1;
            const int ROW_FINISH = 2;
            const int COLUMN_FINISH = 3;
            const int EARLIEST_START = 4;
            const int LATEST_FINISH = 5;

            return ridesInfo.Select((rideInfo, i) =>
            {
                var start = new Coordinate { X = rideInfo[ROW_START], Y = rideInfo[COLUMN_START] };
                var end = new Coordinate { X = rideInfo[ROW_FINISH], Y = rideInfo[COLUMN_FINISH] };
                var ride = new Ride(i)
                {
                    RidePath = new Path(start, end),
                    StartStep = rideInfo[EARLIEST_START],
                    EndStep = rideInfo[LATEST_FINISH]
                };
                return ride;
            }).ToArray();
        }

        private static IEnumerable<int[]> AsNumeric(this IEnumerable<string> src)
            => src.Select(row => row.Split(' ').Select(c => int.Parse(c)).ToArray());
    }
}

using System;
using Scheduler.Models;

namespace Scheduler.Extentions
{
    public static class PathExtentions
    {
        public static int PathLength(this Coordinate start,Coordinate end)
            => Math.Abs(end.X - start.X) + Math.Abs(end.Y - start.Y);
    }
}
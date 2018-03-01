using System;

namespace Scheduler.Models
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Coordinate other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public bool Equals(object other)
        {
            if (other is Coordinate c)
                return this.Equals(c);
            return false;
        }

        public static bool operator ==(Coordinate left, Coordinate right)
            => left.Equals(right);

        public static bool operator !=(Coordinate left, Coordinate right)
            => !left.Equals(right);

        public override int GetHashCode()
        {
            var i = 0;

            unchecked
            {
                i += X.GetHashCode();
                i += Y.GetHashCode();
            }

            return i;
        }
    }
}

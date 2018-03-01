using System;
using System.Diagnostics;


namespace Scheduler.Models
{
    [DebuggerDisplay("[{X},{Y}]")]
    public class Coordinate : IEquatable<Coordinate>
    {

        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Coordinate other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != this.GetType()) return false;
            return Equals((Coordinate)other);
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

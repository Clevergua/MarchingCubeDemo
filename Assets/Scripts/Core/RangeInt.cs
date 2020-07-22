using UnityEngine;
using System.Collections;
using System;

namespace Core
{
    public struct RangeInt : IEquatable<RangeInt>
    {
        public int min;
        public int max;

        public RangeInt(int min, int max)
        {
            if (min < max)
            {
                throw new Exception("Invalid minimum and maximum");
            }
            this.min = min;
            this.max = max;
        }

        public bool InRange(int value)
        {
            return (value >= min && value <= max);
        }

        public override bool Equals(object obj)
        {
            return obj is RangeInt @int && Equals(@int);
        }

        public bool Equals(RangeInt other)
        {
            return min == other.min &&
                   max == other.max;
        }

        public override int GetHashCode()
        {
            var hashCode = -897720056;
            hashCode = hashCode * -1521134295 + min.GetHashCode();
            hashCode = hashCode * -1521134295 + max.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(RangeInt left, RangeInt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RangeInt left, RangeInt right)
        {
            return !(left == right);
        }
    }
}


using System;

namespace Core
{
    public struct Coord2Int : IEquatable<Coord2Int>
    {
        public int x;
        public int y;

        public static Coord2Int zero = new Coord2Int(0, 0);
        public static Coord2Int left = new Coord2Int(-1, 0);
        public static Coord2Int right = new Coord2Int(1, 0);
        public static Coord2Int up = new Coord2Int(0, 1);
        public static Coord2Int down = new Coord2Int(0, -1);
        public static Coord2Int one = new Coord2Int(1, 1);

        public static int ManhattanDistance(Coord2Int coord1, Coord2Int coord2)
        {
            var sx = coord1.x - coord2.x;
            sx = sx > 0 ? sx : -sx;
            var sy = coord1.y - coord2.y;
            sy = sy > 0 ? sy : -sy;
            return sx + sy;
        }
        public Coord2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Coord2Int @int && Equals(@int);
        }

        public bool Equals(Coord2Int other)
        {
            return x == other.x &&
                   y == other.y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public static bool operator ==(Coord2Int left, Coord2Int right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coord2Int left, Coord2Int right)
        {
            return !(left == right);
        }
        public static Coord2Int operator +(Coord2Int left, Coord2Int right)
        {
            return new Coord2Int(left.x + right.x, left.y + right.y);
        }
        public static Coord2Int operator -(Coord2Int left, Coord2Int right)
        {
            return new Coord2Int(left.x - right.x, left.y - right.y);
        }
        public static Coord2Int operator -(Coord2Int c)
        {
            return new Coord2Int(-c.x, -c.y);
        }
        public static Coord2Int operator /(Coord2Int left, int right)
        {
            return new Coord2Int(left.x / right, left.y / right);
        }
        public static Coord2Int operator *(Coord2Int left, int right)
        {
            return new Coord2Int(left.x * right, left.y * right);
        }
        public static Coord2Int operator *(int left, Coord2Int right)
        {
            return new Coord2Int(left * right.x, left * right.y);
        }
    }
}

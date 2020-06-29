using System;
namespace Math
{
    public struct Coord3Int : IEquatable<Coord3Int>
    {
        public int x, y, z;

        public Coord3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override bool Equals(object obj)
        {
            return obj is Coord3Int @int && Equals(@int);
        }
        public bool Equals(Coord3Int other)
        {
            return x == other.x &&
                   y == other.y &&
                   z == other.z;
        }
        public override int GetHashCode()
        {
            var hashCode = 373119288;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Coord3Int left, Coord3Int right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coord3Int left, Coord3Int right)
        {
            return !(left == right);
        }

        public static Coord3Int operator *(Coord3Int left, int right)
        {
            return new Coord3Int(left.x * right, left.y * right, left.z * right);
        }
        public static Coord3Int operator *(int left, Coord3Int right)
        {
            return new Coord3Int(left * right.x, left * right.y, left * right.z);
        }
    }
}
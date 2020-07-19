namespace Core
{
    public static class RNG
    {
        private static readonly int X_PRIME = 16197;
        private static readonly int Y_PRIME = 31337;
        private static readonly int Z_PRIME = 6971;

        public static int Random1(int x, int seed)
        {
            int value = seed;
            value ^= X_PRIME * x + X_PRIME;
            value = value * value * value * 72377;
            value = value >> 23 ^ value;
            return value;
        }
        public static int Random2(int x, int y, int seed)
        {
            int value = seed;
            value ^= X_PRIME * x + X_PRIME;
            value ^= Y_PRIME * y - Y_PRIME;
            value = value * value * value * 7547;
            value = value >> 17 ^ value;
            return value;
        }
        public static int Random3(int x, int y, int z, int seed)
        {
            int value = seed;
            value ^= X_PRIME * x - X_PRIME;
            value ^= Y_PRIME * y + Y_PRIME;
            value ^= Z_PRIME * z - Z_PRIME;
            value = value * value * value * 7547;
            value = value >> 11 ^ value;
            return value;
        }
    }
}
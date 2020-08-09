using System;
namespace Core
{
    public class PerlinNoise
    {
        private static readonly Coord2Int[] GRAD_2D =
        {
            new Coord2Int(-1,-1), new Coord2Int( 1,-1), new Coord2Int(-1, 1), new Coord2Int( 1, 1),
            new Coord2Int( 0,-1), new Coord2Int(-1, 0), new Coord2Int( 0, 1), new Coord2Int( 1, 0),
        };

        private static readonly Coord3Int[] GRAD_3D =
        {
            new Coord3Int( 1, 1, 0), new Coord3Int(-1, 1, 0), new Coord3Int( 1,-1, 0), new Coord3Int(-1,-1, 0),
            new Coord3Int( 1, 0, 1), new Coord3Int(-1, 0, 1), new Coord3Int( 1, 0,-1), new Coord3Int(-1, 0,-1),
            new Coord3Int( 0, 1, 1), new Coord3Int( 0,-1, 1), new Coord3Int( 0, 1,-1), new Coord3Int( 0,-1,-1),
            new Coord3Int( 1, 1, 0), new Coord3Int( 0,-1, 1), new Coord3Int(-1, 1, 0), new Coord3Int( 0,-1,-1),
        };

        private static float SmoothLerp(float a, float b, float t)
        {
            t = t * t * t * (6 * t * t - 15 * t + 10);
            return a + (b - a) * t;
        }

        private static Coord2Int GetGradient2D(int x, int y, int seed)
        {
            int hash = RNG.Random2(x, y, seed);

            int index = hash % 8;
            if (index < 0) index += 8;
            return GRAD_2D[index];
        }

        private static Coord3Int GetGradient3D(int x, int y, int z, int seed)
        {
            int hash = RNG.Random3(x, y, z, seed);

            int index = hash % 16;
            if (index < 0) index += 16;
            return GRAD_3D[index];
        }
        private static float DotGridGradient2D(int ix, int iy, float x, float y, int seed)
        {
            float dx = x - ix;
            float dy = y - iy;

            Coord2Int gradient = GetGradient2D(ix, iy, seed);
            return dx * gradient.x + dy * gradient.y;
        }
        private static float DotGridGradient3D(int ix, int iy, int iz, float x, float y, float z, int seed)
        {
            float dx = x - ix;
            float dy = y - iy;
            float dz = z - iz;

            Coord3Int gradient = GetGradient3D(ix, iy, iz, seed);
            return dx * gradient.x + dy * gradient.y + dz * gradient.z;
        }

        /// <summary>
        /// 范围约为-0.633~0.633
        /// 返回时候可以根据需求通过*1.578955678714098将值定在-1~1,此时占比约算:
        /// -1~-0.8 : 2.2%
        /// -0.8~-0.6 : 9.0%
        /// -0.6~-0.4 : 9.2%
        /// -0.4~-0.2 : 12.8%
        /// -0.2~0 : 16.6%
        /// ...整数与之对称
        /// 0.8~1 : 2.2%
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float PerlinNoise2D(int seed, float x, float y)
        {
            // Determine grid cell coordinates
            int x0 = (int)Math.Floor(x);
            int x1 = x0 + 1;
            int y0 = (int)Math.Floor(y);
            int y1 = y0 + 1;
            // Determine interpolation weights
            // Could also use higher order polynomial/s-curve here
            float sx = x - x0;
            float sy = y - y0;
            // Interpolate between grid point gradients
            float n0, n1, ix0, ix1, value;
            n0 = DotGridGradient2D(x0, y0, x, y, seed);
            n1 = DotGridGradient2D(x1, y0, x, y, seed);
            ix0 = SmoothLerp(n0, n1, sx);
            n0 = DotGridGradient2D(x0, y1, x, y, seed);
            n1 = DotGridGradient2D(x1, y1, x, y, seed);
            ix1 = SmoothLerp(n0, n1, sx);
            value = SmoothLerp(ix0, ix1, sy);

            return value;
        }
        public static float PerlinNoise3D(int seed, float x, float y, float z)
        {
            // Determine grid cell coordinates
            int x0 = (int)Math.Floor(x);
            int x1 = x0 + 1;
            int y0 = (int)Math.Floor(y);
            int y1 = y0 + 1;
            int z0 = (int)Math.Floor(z);
            int z1 = z0 + 1;
            // Determine interpolation weights
            // Could also use higher order polynomial/s-curve here
            float sx = x - x0;
            float sy = y - y0;
            float sz = z - z0;
            // Interpolate between grid point gradients
            float xf00 = SmoothLerp(DotGridGradient3D(x0, y0, z0, x, y, z, seed), DotGridGradient3D(x1, y0, z0, x, y, z, seed), sx);
            float xf10 = SmoothLerp(DotGridGradient3D(x0, y1, z0, x, y, z, seed), DotGridGradient3D(x1, y1, z0, x, y, z, seed), sx);
            float xf01 = SmoothLerp(DotGridGradient3D(x0, y0, z1, x, y, z, seed), DotGridGradient3D(x1, y0, z1, x, y, z, seed), sx);
            float xf11 = SmoothLerp(DotGridGradient3D(x0, y1, z1, x, y, z, seed), DotGridGradient3D(x1, y1, z1, x, y, z, seed), sx);

            float yf0 = SmoothLerp(xf00, xf10, sy);
            float yf1 = SmoothLerp(xf01, xf11, sy);

            return SmoothLerp(yf0, yf1, sz);
        }
        public static float SuperimposedOctave3D(int seed, float x, float y, float z, int superposition = 1)
        {
            if (superposition < 1)
            {
                throw new Exception("Parameter superposition must be greater than 1");
            }
            float result = 0;
            superposition = superposition < 0 ? 0 : superposition;
            for (int i = 0; i < superposition; i++)
            {
                float nIthPower = Pow(2, i);
                result += PerlinNoise3D(seed + i, nIthPower * x, nIthPower * y, nIthPower * z) * Pow(0.5f, i);
            }
            return result;
        }
        private static float Pow(float f, int p)
        {
            float res = f;
            for (int i = 1; i < p; i++) { res *= f; }
            return res;
        }

        public static float SuperimposedOctave2D(int seed, float x, float y, int superposition = 1)
        {
            float result = 0;
            superposition = superposition < 0 ? 0 : superposition;
            for (int i = 0; i < superposition; i++)
            {
                float nIthPower = Pow(2, i);
                result += PerlinNoise2D(seed + i, nIthPower * x, nIthPower * y) * Pow(0.5f, i);
            }
            return result;
        }

    }
}
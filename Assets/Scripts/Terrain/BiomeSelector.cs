using System;

namespace Terrain
{
    internal class BiomeSelector
    {
        public BiomeSelector()
        {
        }

        internal Biome Select(int altitudeTemperature, int humidity)
        {
            return new GrassLand();
        }
    }
}
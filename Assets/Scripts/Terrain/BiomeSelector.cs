using System;

namespace Terrain
{
    internal class BiomeSelector
    {
        private GrassLand grassLand;
        public BiomeSelector()
        {
            grassLand = new GrassLand();
        }

        internal Biome Select(int altitudeTemperature, int humidity)
        {
            return grassLand;
        }
    }
}
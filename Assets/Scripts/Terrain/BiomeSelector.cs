using System;

namespace Terrain
{
    internal class BiomeSelector
    {
        private GrassLand grassLand;
        private SnowyLand snowyLand;
        public BiomeSelector()
        {
            grassLand = new GrassLand();
            snowyLand = new SnowyLand();
        }

        internal Biome Select(int altitudeTemperature, int humidity)
        {
            if (altitudeTemperature < 30 || altitudeTemperature > 70)
            {
                return snowyLand;
            }
            else
            {
                return grassLand;

            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Terrain
{
    internal class BiomeSelector
    {
        private GrassLand grassLand;
        private SnowyLand snowyLand;
        public BiomeSelector(IReadOnlyDictionary<EnvironmentDegree,Biome> biomeLibrary)
        {
            grassLand = new GrassLand();
            snowyLand = new SnowyLand();
        }

        internal Biome Select(int altitudeTemperature, int humidity)
        {
            if (altitudeTemperature < 25 || altitudeTemperature > 75)
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
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Terrain
{
    internal class BiomeSelector
    {
        private IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome;

        public BiomeSelector(IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome)
        {
            this.environmentDegree2Biome = environmentDegree2Biome;
        }

        internal Biome Select(int altitudeTemperature, int humidity)
        {
            if (altitudeTemperature < 33)
            {
                if (humidity < 33)
                {
                    return environmentDegree2Biome[EnvironmentDegree.LowTemperatureLowHumidity];
                }
                else if (humidity < 66)
                {
                    return environmentDegree2Biome[EnvironmentDegree.LowTemperatureMediumHumidity];
                }
                else
                {
                    return environmentDegree2Biome[EnvironmentDegree.LowTemperatureHighHumidity];
                }
            }
            else if (altitudeTemperature < 66)
            {
                if (humidity < 33)
                {
                    return environmentDegree2Biome[EnvironmentDegree.MediumTemperatureLowHumidity];
                }
                else if (humidity < 66)
                {
                    return environmentDegree2Biome[EnvironmentDegree.MediumTemperatureLowHumidity];
                }
                else
                {
                    return environmentDegree2Biome[EnvironmentDegree.MediumTemperatureLowHumidity];
                }
            }
            else
            {
                if (humidity < 33)
                {
                    return environmentDegree2Biome[EnvironmentDegree.HighTemperatureLowHumidity];
                }
                else if (humidity < 66)
                {
                    return environmentDegree2Biome[EnvironmentDegree.HighTemperatureLowHumidity];
                }
                else
                {
                    return environmentDegree2Biome[EnvironmentDegree.HighTemperatureLowHumidity];
                }
            }
        }
    }
}
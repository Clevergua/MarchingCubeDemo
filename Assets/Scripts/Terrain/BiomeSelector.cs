using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Terrain
{
    internal class BiomeSelector
    {
        private Dictionary<EnvironmentDegree, Biome> environmentDegree2Biome;
        public BiomeSelector(IReadOnlyDictionary<EnvironmentDegree, string> environmentDegree2BiomeName)
        {
            environmentDegree2Biome = new Dictionary<EnvironmentDegree, Biome>();
            var assembly = Assembly.GetExecutingAssembly();
            var typeName2Instance = new Dictionary<string, Biome>();
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Biome)) && !type.IsAbstract)
                {
                    var instance = Activator.CreateInstance(type) as Biome;
                    typeName2Instance.Add(type.Name, instance);
                }
            }
            foreach (var pair in environmentDegree2BiomeName)
            {
                environmentDegree2Biome.Add(pair.Key, typeName2Instance[pair.Value]);
            }
        }
        internal Biome Select(int altitudeTemperature, int humidity)
        {
            //return new GrassLand(structureFactory);
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
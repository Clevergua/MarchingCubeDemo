using Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    public class TerrainGenerator
    {
        private int previousRandomNum;
        public Layer CreateLayer(int seed, int worldLength, Biome biome)
        {
            var length = worldLength * Constants.ChunkLength;
            var height = Constants.WorldHeight * Constants.ChunkLength;

            var heightmap = new int[length, length];
            var temperaturemap = new int[length, length];
            var humiditymap = new int[length, length];

            var structuremap = new int[length, length];
            var structures = new List<Structure>();
            var blockmap = new int[length, height, length];

            FillEnvironmentalmaps(seed, length, heightmap, temperaturemap, humiditymap);

            var territorymap = new int[length, length];
            var id2Territory = new List<Territory>();

            FillTerritorymap(seed, territorymap, id2Territory);

            return new Layer(null, null);
        }

        private void FillTerritorymap(int seed, int[,] territorymap, List<Territory> id2Territory)
        {
            //分布必须的领地
            var necessaryTerritories = new List<Territory>();

            necessaryTerritories.Add(new AdventurerTerritory());
            necessaryTerritories.Add(new BossTerritory());
            necessaryTerritories.Add(new CityTerritory());

            foreach (var territory in necessaryTerritories)
            {
                var numOfAttempts = 0;
                while (true)
                {
                    numOfAttempts++;
                    if (numOfAttempts < 256)
                    {
                        if (TrySetTerritory(territory, territorymap, id2Territory, seed)) { break; }
                    }
                    else
                    {
                        throw new Exception("The map is too small");
                    }
                }
            }
            //分布其他的领地

            var normalTerritories = GetNormalTerritories(seed);


        }

        private List<Territory> GetNormalTerritories(int seed)
        {
            var r = RNG.Random1(568731, seed);
            var count = Mathf.Abs(r % Constants.MaxNormalTerritoryCount - Constants.MinNormalTerritoryCount) + Constants.MinNormalTerritoryCount;
            for (int i = 0; i < count; i++)
            {
                NormalTerritoryLibrary
                var index = 
                
            }
        }

        private bool TrySetTerritory(Territory territory, int[,] territorymap, List<Territory> id2Territory, int seed)
        {
            var success = true;

            var length = territorymap.GetLength(0);
            var range = territory.Range;
            var rangeCount = (length - 2 * range);
            var cx = Math.Abs(GetNextRandomInt(seed) % rangeCount) + range;
            var cy = Math.Abs(GetNextRandomInt(seed) % rangeCount) + range;
            for (int x = cx - range; x < cx + range; x++)
            {
                for (int y = cy - range; y < cy + range; y++)
                {
                    var dx = x - cx;
                    var dy = y - cy;
                    //If within range
                    if (range * range <= dx * dx + dy * dy)
                    {
                        if (territorymap[x, y] == 0)
                        {
                            //Do nothing
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }
            }

            if (success)
            {
                var index = id2Territory.Count;
                id2Territory.Add(territory);
                for (int x = cx - range; x < cx + range; x++)
                {
                    for (int y = cy - range; y < cy + range; y++)
                    {
                        var dx = x - cx;
                        var dy = y - cy;
                        //If within range
                        if (range * range <= dx * dx + dy * dy)
                        {
                            territorymap[x, y] = index;
                        }
                    }
                }
            }
            else
            {
                //Do nothing
            }

            return success;
        }

        private int GetNextRandomInt(int seed)
        {
            var value = RNG.Random1(previousRandomNum, seed);
            previousRandomNum = value * value * value - 779789777 << 6585;
            return value;
        }

        private void FillEnvironmentalmaps(int seed, int length, int[,] heightmap, int[,] temperaturemap, int[,] humiditymap)
        {
            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    var heightNoiseDensity = 0.0003f;
                    var heightNoise = PerlinNoise.PerlinNoise2D(seed + 1232, x * heightNoiseDensity, z * heightNoiseDensity) * 0.5f + 0.5f;
                    heightmap[x, z] = (int)(Mathf.Lerp(Constants.MinHeight, Constants.MaxHeight, heightNoise));

                    var temperatureNoiseDensity = 0.0007f;
                    var temperatureNoise = PerlinNoise.PerlinNoise2D(seed + 8674, x * temperatureNoiseDensity, z * temperatureNoiseDensity) * 0.5f + 0.5f;
                    temperaturemap[x, z] = (int)(Mathf.Lerp(Constants.MinTemperature, Constants.MaxTemperature, temperatureNoise));

                    var humidityNoiseDensity = 0.0007f;
                    var humidityNoise = PerlinNoise.PerlinNoise2D(seed + 96, x * humidityNoiseDensity, z * humidityNoiseDensity) * 0.5f + 0.5f;
                    humiditymap[x, z] = (int)(Mathf.Lerp(Constants.MinHumidity, Constants.MaxHumidity, humidityNoise));
                }
            }
        }

    }
}

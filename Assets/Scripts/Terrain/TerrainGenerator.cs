using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Terrain
{
    public class TerrainGenerator
    {
        private int previousRandomNum;

        public Layer CreateLayer(int seed, int worldLength)
        {
            var length = worldLength * Constants.ChunkLength;
            //var height = Constants.WorldHeight * Constants.ChunkLength;
            var heightmap = new int[length, length];
            var temperaturemap = new int[length, length];
            var humiditymap = new int[length, length];

            FillEnvironmentalmaps(seed, length, heightmap, temperaturemap, humiditymap);

            var territorymap = new int[length, length];
            var id2Territory = new List<Territory>();
            var territorySeed = seed;

            while (!TryFillTerritorymap(territorySeed, territorymap, id2Territory))
            {
                territorySeed++;
            }
            var times = territorySeed - seed + 1;
            if (times < 3)
            {
                Debug.Log($"Try to fill the territory {times} times");
            }
            else
            {
                Debug.LogWarning($"Try to fill the territory {times} times");
            }



            #region 生成图片查看结果
            var texture = new Texture2D(length, length, TextureFormat.ARGB32, false);

            var territoryType2Color = new Dictionary<Type, Color>();
            foreach (var item in id2Territory)
            {
                var t = item.GetType();
                if (!territoryType2Color.ContainsKey(t))
                {
                    var c = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                    territoryType2Color.Add(t, c);
                }
            }
            // set the pixel values
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    var index = territorymap[x, y];
                    if (index == -1)
                    {
                        var c = new Color((float)temperaturemap[x, y] / 100, 0, 0);
                        texture.SetPixel(x, y, c);
                    }
                    else
                    {
                        texture.SetPixel(x, y, territoryType2Color[id2Territory[index].GetType()]);
                    }

                }
            }
            // Apply all SetPixel calls
            texture.Apply();
            byte[] bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes($"{Application.dataPath}/aa.png", bytes);
            #endregion

            return new Layer(null, null);
        }

        private bool TryFillTerritorymap(int seed, int[,] territorymap, List<Territory> id2Territory)
        {
            var success = true;
            //重置
            for (int x = 0; x < territorymap.Length; x++)
            {
                for (int y = 0; y < territorymap.Length; y++)
                {
                    territorymap[x, y] = -1;
                }
            }
            id2Territory.Clear();

            var specialTerritoryTypes = new List<Type>();
            var normalTerritoryTypes = new List<Type>();

            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(SpecialTerritory)))
                {
                    specialTerritoryTypes.Add(type);
                }
                else if (type.IsSubclassOf(typeof(NormalTerritory)))
                {
                    normalTerritoryTypes.Add(type);
                }
            }

            //产生领地特殊集合
            var specialTerritories = new List<SpecialTerritory>();
            foreach (var type in specialTerritoryTypes)
            {
                var instance = Activator.CreateInstance(type);
                specialTerritories.Add(instance as SpecialTerritory);
            }
            //分布特殊的领地
            foreach (var territory in specialTerritories)
            {
                var numOfAttempts = 0;
                while (true)
                {
                    numOfAttempts++;
                    if (numOfAttempts < 512)
                    {
                        if (TrySetTerritory(territory, territorymap, id2Territory, seed)) { break; }
                    }
                    else
                    {
                        Debug.Log("The map is too small");
                        return false;
                    }
                }
            }
            //产生领地集合
            var normalTerritories = new List<NormalTerritory>();
            var count = Mathf.Abs(RNG.Random1(8731, seed) % Constants.MaxNormalTerritoryCount - Constants.MinNormalTerritoryCount) + Constants.MinNormalTerritoryCount;
            for (int i = 0; i < count; i++)
            {
                var index = Mathf.Abs(GetNextRandomInt(seed) % normalTerritoryTypes.Count);
                var type = normalTerritoryTypes[index];
                var instance = Activator.CreateInstance(type) as NormalTerritory;
                normalTerritories.Add(instance);
            }
            //按范围从大到小排列
            normalTerritories.Sort((left, right) =>
            {
                return right.Range - left.Range;
            });
            //分布普通领地
            foreach (var territory in normalTerritories)
            {
                var numOfAttempts = 0;
                while (true)
                {
                    numOfAttempts++;
                    if (numOfAttempts < 512)
                    {
                        if (TrySetTerritory(territory, territorymap, id2Territory, seed)) { break; }
                    }
                    else
                    {
                        Debug.Log("The map is too small");
                        success = false;
                    }
                }
            }

            return success;
        }
        private bool TrySetTerritory(Territory territory, int[,] territorymap, List<Territory> id2Territory, int seed)
        {
            var success = true;

            var length = territorymap.GetLength(0);
            var range = territory.Range;
            var rangeCount = (length - 2 * range);
            var vx = GetNextRandomInt(seed);
            var vy = GetNextRandomInt(seed);
            var cx = Math.Abs(vx % rangeCount) + range;
            var cy = Math.Abs(vy % rangeCount) + range;
            for (int x = cx - range; x < cx + range; x++)
            {
                for (int y = cy - range; y < cy + range; y++)
                {
                    var dx = x - cx;
                    var dy = y - cy;
                    //If within range
                    if (range * range <= dx * dx + dy * dy)
                    {
                        if (territorymap[x, y] == -1)
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
                        if (dx * dx + dy * dy <= range * range)
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
            previousRandomNum = value;
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

                    var temperatureNoiseDensity = 0.0011f;
                    var temperatureNoise = PerlinNoise.PerlinNoise2D(seed + 8674, x * temperatureNoiseDensity, z * temperatureNoiseDensity) * 0.5f + 0.5f;
                    temperaturemap[x, z] = (int)(Mathf.Lerp(Constants.MinTemperature, Constants.MaxTemperature, temperatureNoise));

                    var humidityNoiseDensity = 0.0011f;
                    var humidityNoise = PerlinNoise.PerlinNoise2D(seed + 96, x * humidityNoiseDensity, z * humidityNoiseDensity) * 0.5f + 0.5f;
                    humiditymap[x, z] = (int)(Mathf.Lerp(Constants.MinHumidity, Constants.MaxHumidity, humidityNoise));
                }
            }
        }

    }
}

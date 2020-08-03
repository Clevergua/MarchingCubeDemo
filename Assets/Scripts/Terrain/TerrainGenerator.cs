using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    public class TerrainGenerator
    {
        public int progress { get; private set; }
        public Layer result { get; private set; }
        public string currentOperation { get; private set; }
        public bool isDone { get; private set; } = false;

        private int previousRandomNum;

        public IEnumerator TTT()
        {
            var seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            Debug.Log(seed);

            var grassLand = new GrassLand();

            IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome = new Dictionary<EnvironmentDegree, Biome>()
            {
                { EnvironmentDegree.LowTemperatureLowHumidity, grassLand},
                { EnvironmentDegree.LowTemperatureMediumHumidity, grassLand},
                { EnvironmentDegree.LowTemperatureHighHumidity, grassLand},

                { EnvironmentDegree.MediumTemperatureLowHumidity, grassLand},
                { EnvironmentDegree.MediumTemperatureMediumHumidity, grassLand},
                { EnvironmentDegree.MediumTemperatureHighHumidity, grassLand},

                { EnvironmentDegree.HighTemperatureLowHumidity, grassLand},
                { EnvironmentDegree.HighTemperatureMediumHumidity, grassLand},
                { EnvironmentDegree.HighTemperatureHighHumidity, grassLand},
            };

            yield return GenerateIsland(seed, 16, environmentDegree2Biome);
        }



        internal IEnumerator<Island> GenerateIsland(int seed, int worldLength, IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome)
        {
            var length = worldLength * Constants.ChunkLength;

            Environmentmap environmentmap = null;
            {
                currentOperation = "正在生成环境图";
                progress = 5;
                yield return null;

                var enumerator = FillEnvironmentalmaps(seed, length, environmentDegree2Biome);
                while (enumerator.MoveNext()) { yield return null; }
                environmentmap = enumerator.Current;
            }

            Territorymap territorymap = null;
            {
                currentOperation = "正在生成领地图";
                progress = 10;
                yield return null;

                List<Territory> necessaryTerritories = new List<Territory>();
                List<Territory> normalTerritories = new List<Territory>();

                var enumerator = GenerateTerritorymap(necessaryTerritories, normalTerritories, length, seed);
                while (enumerator.MoveNext()) { yield return null; }
                territorymap = enumerator.Current;

                foreach (var item in territorymap.id2Territory)
                {
                    var e = item.GenerateStructuremap(environmentmap, seed);
                    while (e.MoveNext()) { yield return null; }
                    var structuremap = e.Current;
                }
            }

            #region 绘制图
            var texture = new Texture2D(length, length, TextureFormat.ARGB32, false);
            var territoryType2Color = new Dictionary<Type, Color>();
            foreach (var item in territorymap.id2Territory)
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

                    var index = territorymap.coord2ID[x, y];
                    if (index == -1)
                    {
                        //if (pathmap[x, y] != -1)
                        //{
                        //    texture.SetPixel(x, y, Color.green);
                        //}
                        //else
                        //{
                        var c = new Color((float)environmentmap.baseTemperaturemap[x, y] / 100, 0, 0);
                        texture.SetPixel(x, y, c);
                        //}
                    }
                    else
                    {
                        texture.SetPixel(x, y, territoryType2Color[territorymap.id2Territory[index].GetType()]);
                    }

                }
            }
            //foreach (var item in coord2MinDistanceFromPath)
            //{
            //    texture.SetPixel(item.Key.x, item.Key.z, Color.green);
            //}
            // Apply all SetPixel calls
            texture.Apply();
            byte[] bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes($"{Application.dataPath}/aa.png", bytes);
            #endregion

            ////生成建筑工厂
            //var structureFactory = new StructureFactory();

            ////填充建筑数据图
            //var structuredatamap = new int[length, length];
            //var id2StructureData = new List<StructureData>();
            //yield return FillTerritoryStructuredatamap(structuredatamap, id2StructureData, id2Territory, seed, structureFactory, heightmap, temperaturemap, humiditymap, biomeSelector);

            //currentOperation = "正在生成路径图";
            //progress = 15;
            //yield return null;
            ////路径信息
            //var paths = new List<Path>();
            //yield return GeneratePaths(paths, id2Territory, territorymap);
            //var coord2MinDistanceFromPath = new Dictionary<Coord3Int, int>();
            //yield return GenerateCoord2MinDistanceFromPath(coord2MinDistanceFromPath, paths, length, height, heightmap);

            //currentOperation = "正在生成噪声图";
            //progress = 40;
            //yield return null;
            ////生成3D噪声图和凹洞的字典数据
            //var blockmap = new byte[length, height, length];
            ////处理后的数据:0:空 1:实体 2:凹洞
            //yield return NoiseBlockmap(blockmap, heightmap, territorymap, id2Territory, coord2MinDistanceFromPath, seed);

            //currentOperation = "正在填充水和岩浆";
            //progress = 45;
            //yield return null;
            //yield return FillPits(blockmap, biomeSelector, temperaturemap, humiditymap, heightmap, seed);

            //currentOperation = "正在创建地表";
            //progress = 55;
            //yield return null;
            //yield return CreateSurfaceLayer(blockmap, biomeSelector, temperaturemap, humiditymap, heightmap, seed);

            //currentOperation = "正在进行种植";
            //progress = 60;
            //yield return null;
            //yield return CreatePlants(blockmap, biomeSelector, temperaturemap, humiditymap, heightmap, territorymap, id2Territory, coord2MinDistanceFromPath, seed);

            //currentOperation = "正在构建领地";
            //progress = 70;
            //yield return GenerateStructuresInTerritories(blockmap, biomeSelector, temperaturemap, humiditymap, heightmap, id2Territory, structureFactory, seed);



            //result = new Layer(blockmap);
            progress = 100;
            isDone = true;
        }
        private IEnumerator<Environmentmap> FillEnvironmentalmaps(int seed, int length, IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome)
        {
            var environmentmap = new Environmentmap(length, length, environmentDegree2Biome);
            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    var heightNoiseDensity = 0.007f;
                    var heightNoise = PerlinNoise.PerlinNoise2D(seed + 1232, x * heightNoiseDensity, z * heightNoiseDensity) * 1.578f * 0.5f + 0.5f;
                    environmentmap.baseHeightmap[x, z] = (int)(Mathf.Lerp(Constants.MinHeight, Constants.MaxHeight, heightNoise));

                    var temperatureNoiseDensity = 0.003f;
                    var temperatureNoise = PerlinNoise.PerlinNoise2D(seed + 8674, x * temperatureNoiseDensity, z * temperatureNoiseDensity) * 1.578f;
                    //下面两步处理是为了让噪声分布结果平均
                    var t1 = temperatureNoise * temperatureNoise;
                    temperatureNoise *= 1.4f - 0.4f * t1;

                    temperatureNoise = temperatureNoise * 0.5f + 0.5f;
                    environmentmap.baseTemperaturemap[x, z] = (int)(Mathf.Lerp(Constants.MinTemperature, Constants.MaxTemperature, temperatureNoise));

                    var humidityNoiseDensity = 0.003f;
                    var humidityNoise = PerlinNoise.PerlinNoise2D(seed + 96, x * humidityNoiseDensity, z * humidityNoiseDensity) * 1.578f;
                    var t2 = humidityNoise * humidityNoise;
                    humidityNoise *= 1.4f - 0.4f * t2;

                    humidityNoise = humidityNoise * 0.5f + 0.5f;
                    environmentmap.baseHumiditymap[x, z] = (int)(Mathf.Lerp(Constants.MinHumidity, Constants.MaxHumidity, humidityNoise));
                }
                yield return null;
            }
            yield return environmentmap;
        }
        private IEnumerator<Territorymap> GenerateTerritorymap(List<Territory> necessaryTerritories, List<Territory> normalTerritories, int length, int seed)
        {
            Territorymap territorymap = new Territorymap(length, length);
            //填充必要领地
            {
                //根据范围进行排序
                necessaryTerritories.Sort((l, r) => { return r.Range - l.Range; });
                var tempSeed = seed;
                var times = 0;
                while (!TrySetNecessaryTerritories(territorymap, necessaryTerritories, tempSeed))
                {
                    times++;
                    if (times > 8)
                    {
                        throw new Exception("Too many attempts when generating necessary territory");
                    }
                    tempSeed++;
                }
            }
            //填充非必要领地
            {
                //根据范围进行排序
                normalTerritories.Sort((l, r) => { return r.Range - l.Range; });
                foreach (var t in normalTerritories)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (TrySetTerritory(t, territorymap, seed + i)) { break; }
                    }
                }
            }
            yield return territorymap;
        }
        private bool TrySetNecessaryTerritories(Territorymap territorymap, IReadOnlyList<Territory> necessaryTerritories, int seed)
        {
            territorymap.Reset();
            foreach (var territory in necessaryTerritories)
            {
                var times = 0;
                while (true)
                {
                    times++;
                    if (times < 8)
                    {
                        if (TrySetTerritory(territory, territorymap, seed)) { break; }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool TrySetTerritory(Territory territory, Territorymap territorymap, int seed)
        {
            var success = true;
            var length = territorymap.coord2ID.GetLength(0);
            var territoryLength = territory.Range;
            var rangeCount = (length - 2 * territoryLength);
            var rx = GetNextRandomInt(seed);
            var ry = GetNextRandomInt(seed);
            var cx = Math.Abs(rx % rangeCount) + territoryLength;
            var cy = Math.Abs(ry % rangeCount) + territoryLength;
            for (int x = cx - territoryLength; x < cx + territoryLength; x++)
            {
                for (int y = cy - territoryLength; y < cy + territoryLength; y++)
                {
                    if (territorymap.coord2ID[x, y] == -1)
                    {
                        //Do nothing
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            if (success)
            {
                var index = territorymap.id2Territory.Count;
                territorymap.id2Territory.Add(territory);
                territory.WorldCoord = new Coord2Int(cx, cy);

                for (int x = cx - territoryLength; x < cx + territoryLength; x++)
                {
                    for (int y = cy - territoryLength; y < cy + territoryLength; y++)
                    {
                        territorymap.coord2ID[x, y] = index;
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


        //private IEnumerator FillTerritoryStructuredatamap(int[,] structuredatamap, List<StructureData> id2StructureData, IEnumerable<Territory> id2Territory, int seed, StructureFactory structureFactory, int[,] heightmap, int[,] temperaturemap, int[,] humiditymap, BiomeSelector biomeSelector)
        //{
        //    foreach (var territory in id2Territory)
        //    {
        //        var territoryLength = territory.Range * 2 + 1;
        //        var localStructuredatamap = new int[territoryLength, territoryLength];
        //        var localID2StructureData = new List<StructureData>();
        //        //为了领地的自由创建传入更多的参数作为参考信息
        //        yield return territory.GenerateStructuremap(localStructuredatamap, localID2StructureData, seed, structureFactory, heightmap, temperaturemap, humiditymap, biomeSelector);
        //        var currentCount = id2StructureData.Count;
        //        for (int x = 0; x < territoryLength; x++)
        //        {
        //            for (int z = 0; z < territoryLength; z++)
        //            {
        //                var wx = territory.Pivot.x + x - territory.Range;
        //                var wz = territory.Pivot.y + z - territory.Range;
        //                structuredatamap[wx, wz] = localStructuredatamap[x, z] + currentCount;
        //            }
        //        }
        //        id2StructureData.AddRange(localID2StructureData);
        //    }
        //}


        //private IEnumerator GenerateStructuresInTerritories(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, List<Territory> id2Territory, StructureFactory structureFactory, int seed)
        //{
        //    foreach (var territory in id2Territory)
        //    {
        //        territory.ArrangeStructures(blockmap, biomeSelector, temperaturemap, humiditymap, heightmap, structureFactory, seed);
        //        yield return null;
        //    }
        //}

        //private IEnumerator CreatePlants(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, int[,] territorymap, IReadOnlyList<Territory> id2Territory, IReadOnlyDictionary<Coord3Int, int> coord2MinDistanceFromPath, int seed)
        //{
        //    var length = blockmap.GetLength(0);
        //    for (int x = 0; x < length; x++)
        //    {
        //        for (int z = 0; z < length; z++)
        //        {
        //            var altitudeTemperature = Constants.CalTemperature(temperaturemap[x, z], heightmap[x, z]);
        //            var humidity = humiditymap[x, z];
        //            var biome = biomeSelector.Select(altitudeTemperature, humidity);
        //            biome.Planting(blockmap, x, z, temperaturemap, humiditymap, heightmap, territorymap, id2Territory, coord2MinDistanceFromPath, seed);
        //        }
        //        yield return null;
        //    }
        //}
        //private IEnumerator CreateSurfaceLayer(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, int seed)
        //{
        //    var length = blockmap.GetLength(0);
        //    for (int x = 0; x < length; x++)
        //    {
        //        for (int z = 0; z < length; z++)
        //        {
        //            var altitudeTemperature = Constants.CalTemperature(temperaturemap[x, z], heightmap[x, z]);
        //            var humidity = humiditymap[x, z];
        //            var biome = biomeSelector.Select(altitudeTemperature, humidity);
        //            biome.Growing(blockmap, x, z, seed);
        //        }
        //        yield return null;
        //    }
        //}
        //private IEnumerator FillPits(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, int seed)
        //{
        //    var length = blockmap.GetLength(0);
        //    var height = blockmap.GetLength(1);
        //    var processedPitCoords = new HashSet<Coord3Int>();
        //    byte pit = 2;

        //    for (int x = 0; x < length; x++)
        //    {
        //        for (int z = 0; z < length; z++)
        //        {
        //            for (int y = 0; y < height; y++)
        //            {
        //                var currentCoord = new Coord3Int(x, y, z);
        //                //如果当前点是未处理过的凹洞
        //                if (blockmap[x, y, z] == pit && !processedPitCoords.Contains(currentCoord))
        //                {
        //                    //选择一个生物群落来处理凹洞
        //                    var altitudeTemperature = Constants.CalTemperature(temperaturemap[x, z], heightmap[x, z]);
        //                    var humidity = humiditymap[x, z];
        //                    var biome = biomeSelector.Select(altitudeTemperature, humidity);

        //                    var pitCoordsGroup = new List<Coord3Int>();
        //                    var queue = new Queue<Coord3Int>();
        //                    queue.Enqueue(currentCoord);
        //                    pitCoordsGroup.Add(currentCoord);
        //                    processedPitCoords.Add(currentCoord);
        //                    while (queue.Count > 0)
        //                    {
        //                        var current = queue.Dequeue();
        //                        var neighbors = new Coord3Int[]
        //                        {
        //                                new Coord3Int(current.x+1, current.y, current.z),
        //                                new Coord3Int(current.x-1, current.y, current.z),
        //                                new Coord3Int(current.x, current.y+1, current.z),
        //                                new Coord3Int(current.x, current.y-1, current.z),
        //                                new Coord3Int(current.x, current.y, current.z+1),
        //                                new Coord3Int(current.x, current.y, current.z-1)
        //                        };
        //                        foreach (var c in neighbors)
        //                        {
        //                            if (c.x < 0 || c.y < 0 || c.z < 0 || c.x >= length || c.z >= length || c.y >= height)
        //                            {
        //                                //越界抛弃..
        //                            }
        //                            else
        //                            {
        //                                //当周围是凹洞且未被处理
        //                                if (blockmap[c.x, c.y, c.z] == pit && !processedPitCoords.Contains(c))
        //                                {
        //                                    pitCoordsGroup.Add(c);
        //                                    queue.Enqueue(c);
        //                                    processedPitCoords.Add(c);
        //                                }
        //                            }
        //                        }
        //                    }
        //                    biome.ProcessPitCoords(pitCoordsGroup, blockmap, heightmap, seed);
        //                    yield return null;
        //                }
        //            }
        //        }
        //    }
        //}
        //private IEnumerator NoiseBlockmap(byte[,,] blockmap, int[,] heightmap, int[,] territorymap, IReadOnlyList<Territory> id2Territory, IReadOnlyDictionary<Coord3Int, int> coord2MinDistanceFromPath, int seed)
        //{
        //    var length = blockmap.GetLength(0);
        //    var height = blockmap.GetLength(1);

        //    byte entity = 1;
        //    byte pit = 2;


        //    for (int x = 0; x < length; x++)
        //    {
        //        for (int z = 0; z < length; z++)
        //        {
        //            var curHeight = heightmap[x, z];
        //            for (int y = 0; y < height; y++)
        //            {
        //                //使用时候factor范围为0-1
        //                //factor * noise
        //                var currentCoord = new Coord3Int(x, y, z);

        //                //高度差为0的时:heightFactor = 1
        //                //高度差达到NoiseImpactRange时:factor = 0
        //                //更大差值时候:heightFactor < 0
        //                var heightDifference = Mathf.Abs(y - curHeight);
        //                var heightFactor = ((float)Constants.HeightNoiseImpactRange - heightDifference) / Constants.HeightNoiseImpactRange;
        //                //高度噪声倍率: 1.96 ~ 0.16
        //                //减少悬空块的产生
        //                var heightNoiseMagnification = heightFactor + 0.4f;
        //                heightNoiseMagnification *= heightNoiseMagnification;
        //                //在领地中心为:territoryFactor = 0;
        //                //距离领地距离达到Range时:territoryFactor = 1;
        //                //更远距离时候:territoryFactor > 1;
        //                var territoryIndex = territorymap[x, z];
        //                var territoryFactor = 0f;
        //                if (territoryIndex == -1)
        //                {
        //                    territoryFactor = 1;
        //                }
        //                else
        //                {
        //                    var territory = id2Territory[territoryIndex];
        //                    var territoryRange = territory.Range;
        //                    var territoryCenter = territory.WorldCoord;
        //                    var disSquare = (x - territoryCenter.x) * (x - territoryCenter.x) + (y - curHeight) * (y - curHeight) + (z - territoryCenter.y) * (z - territoryCenter.y);
        //                    territoryFactor = (float)disSquare / (territoryRange * territoryRange);
        //                }


        //                //通过coord2MinDistanceFromPath查找并影响权重
        //                //距离道路为0时:pathFactor = 0
        //                //距离道路为Range时:pathFactor = 1
        //                //超出距离时:pathFactor = 1
        //                var pathFactor = 0f;
        //                if (coord2MinDistanceFromPath.ContainsKey(currentCoord))
        //                {
        //                    //dis最小值为0 最大值Constants.PathRange
        //                    var dis = coord2MinDistanceFromPath[currentCoord];
        //                    pathFactor = (float)dis / Constants.PathRange;
        //                    pathFactor *= pathFactor;
        //                }
        //                else
        //                {
        //                    pathFactor = 1;
        //                }

        //                //获取最小值的factory
        //                var factor = float.MaxValue;
        //                var factors = new float[] { heightFactor, territoryFactor, pathFactor };
        //                foreach (var f in factors) { if (f < factor) factor = f; }
        //                factor = Mathf.Clamp(factor, 0, 1);

        //                if (y <= curHeight)
        //                {
        //                    blockmap[x, y, z] = entity;
        //                }
        //                if (factor > 0)
        //                {
        //                    var noiseDensity = 0.03f;
        //                    var noise = PerlinNoise.SuperimposedOctave3D(seed + 2213, x * noiseDensity, y * noiseDensity, z * noiseDensity, 2) * 0.666f;
        //                    noise *= heightNoiseMagnification;
        //                    noise *= factor;
        //                    if (noise > 0.1f)
        //                    {
        //                        blockmap[x, y, z] = entity;
        //                    }
        //                    else if (noise < -0.2f && blockmap[x, y, z] == 1)
        //                    {
        //                        blockmap[x, y, z] = pit;
        //                    }
        //                }
        //            }
        //        }
        //        yield return null;
        //    }
        //}
        //private IEnumerator GenerateCoord2MinDistanceFromPath(Dictionary<Coord3Int, int> coord2MinDistanceFromPath, IReadOnlyList<Path> paths, int length, int height, int[,] heightmap)
        //{
        //    for (int i = 0; i < paths.Count; i++)
        //    {
        //        var path = paths[i];
        //        foreach (var coord2 in path.Coords)
        //        {
        //            var center = new Coord3Int(coord2.x, heightmap[coord2.x, coord2.y], coord2.y);

        //            //限制min,max避免越界
        //            var minx = center.x - Constants.PathRange < 0 ? 0 : center.x - Constants.PathRange;
        //            var miny = center.y - Constants.PathRange < 0 ? 0 : center.y - Constants.PathRange;
        //            var minz = center.z - Constants.PathRange < 0 ? 0 : center.z - Constants.PathRange;

        //            var maxx = center.x + Constants.PathRange < length ? center.x + Constants.PathRange : length - 1;
        //            var maxy = center.y + Constants.PathRange < height ? center.y + Constants.PathRange : height - 1;
        //            var maxz = center.z + Constants.PathRange < length ? center.z + Constants.PathRange : length - 1;

        //            for (int x = minx; x <= maxx; x++)
        //            {
        //                for (int y = miny; y < maxy; y++)
        //                {
        //                    for (int z = minz; z < maxz; z++)
        //                    {
        //                        var current = new Coord3Int(x, y, z);
        //                        var distance = ManhattanDistance3D(center, current);
        //                        if (distance <= Constants.PathRange)
        //                        {
        //                            if (coord2MinDistanceFromPath.ContainsKey(current))
        //                            {
        //                                if (distance < coord2MinDistanceFromPath[current])
        //                                {
        //                                    coord2MinDistanceFromPath[current] = distance;
        //                                }
        //                                else
        //                                {
        //                                    //较大值抛弃
        //                                }
        //                            }
        //                            else
        //                            {
        //                                coord2MinDistanceFromPath.Add(current, distance);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //范围外部的抛弃
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        yield return null;
        //    }
        //}
        //private IReadOnlyList<Coord2Int> GenerateCoordsOnPathByAStar(Coord2Int start, Coord2Int goal, int[,] territorymap)
        //{
        //    var coordOpenSet = new HashSet<Coord2Int>() { start };
        //    var coord2CameFrom = new Dictionary<Coord2Int, Coord2Int>();
        //    var coord2GScore = new Dictionary<Coord2Int, int>() { { start, 0 } };
        //    var coord2FScore = new Dictionary<Coord2Int, int>() { { start, ManhattanDistance2D(start, goal) } };

        //    var startTerritoryIndex = territorymap[start.x, start.y];
        //    var goalTerritoryIndex = territorymap[goal.x, goal.y];
        //    while (coordOpenSet.Count > 0)
        //    {
        //        //获得最小代价点作为当前点
        //        var minFScore = int.MaxValue;
        //        var current = Coord2Int.zero;
        //        foreach (var item in coordOpenSet)
        //        {
        //            if (coord2FScore[item] < minFScore)
        //            {
        //                current = item;
        //                minFScore = coord2FScore[item];
        //            }
        //        }

        //        //如果当前为目标则直接返回
        //        if (current == goal)
        //        {
        //            var coords = new List<Coord2Int>();
        //            while (coord2CameFrom.ContainsKey(current))
        //            {
        //                current = coord2CameFrom[current];
        //                coords.Add(current);
        //            }
        //            coords.Reverse();
        //            return coords;
        //        }
        //        else
        //        {
        //            coordOpenSet.Remove(current);
        //            //遍历所有邻居
        //            for (int i = -1; i < 2; i++)
        //            {
        //                for (int j = -1; j < 2; j++)
        //                {
        //                    var x = current.x + i;
        //                    var z = current.y + j;
        //                    if (i == 0 && j == 0)
        //                    {
        //                        //该点是自身点不是相邻点,排除.
        //                    }
        //                    else if (x < 0 || x >= territorymap.GetLength(0) || z < 0 || z >= territorymap.GetLength(1))
        //                    {
        //                        //越界
        //                    }
        //                    else
        //                    {
        //                        var neighbor = new Coord2Int(x, z);
        //                        //如果相邻点可走
        //                        //这里认为起始和目标领地以及空地可走
        //                        var neighborTerritoryIndex = territorymap[neighbor.x, neighbor.y];
        //                        if (neighborTerritoryIndex == -1 || neighborTerritoryIndex == startTerritoryIndex || neighborTerritoryIndex == goalTerritoryIndex)
        //                        {
        //                            var tentativeGScore = coord2GScore[current] + 1;
        //                            if (!coord2GScore.ContainsKey(neighbor) || tentativeGScore < coord2GScore[neighbor])
        //                            {
        //                                if (coord2CameFrom.ContainsKey(neighbor))
        //                                    coord2CameFrom[neighbor] = current;
        //                                else
        //                                    coord2CameFrom.Add(neighbor, current);

        //                                if (coord2GScore.ContainsKey(neighbor))
        //                                    coord2GScore[neighbor] = tentativeGScore;
        //                                else
        //                                    coord2GScore.Add(neighbor, tentativeGScore);

        //                                if (coord2FScore.ContainsKey(neighbor))
        //                                    coord2FScore[neighbor] = tentativeGScore + ManhattanDistance2D(neighbor, goal);
        //                                else
        //                                    coord2FScore.Add(neighbor, tentativeGScore + ManhattanDistance2D(neighbor, goal));

        //                                if (!coordOpenSet.Contains(neighbor))
        //                                {
        //                                    coordOpenSet.Add(neighbor);
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //相邻位置不可移动,排除.
        //                        }

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    throw new Exception("Open set is empty but goal was never reached!");
        //}
        //private int ManhattanDistance2D(Coord2Int start, Coord2Int goal)
        //{
        //    return Mathf.Abs(start.x - goal.x) + Mathf.Abs(start.y - goal.y);
        //}
        //private int ManhattanDistance3D(Coord3Int start, Coord3Int goal)
        //{
        //    return Mathf.Abs(start.x - goal.x) + Mathf.Abs(start.y - goal.y) + Mathf.Abs(start.z - goal.z);
        //}

        //private IEnumerator GeneratePaths(List<Path> paths, IReadOnlyList<Territory> id2Territory, int[,] territorymap)
        //{
        //    var markedTerritories = new List<Territory>();
        //    var unmarkedTerritories = new List<Territory>();
        //    BossTerritory bossTerritory = null;
        //    foreach (var t in id2Territory)
        //    {
        //        if (t is AdventurerCampTerritory)
        //        {
        //            markedTerritories.Add(t);
        //        }
        //        else
        //        {
        //            if (t is BossTerritory)
        //            {
        //                bossTerritory = t as BossTerritory;
        //            }
        //            else
        //            {
        //                unmarkedTerritories.Add(t);
        //            }
        //        }
        //    }
        //    yield return null;

        //    unmarkedTerritories.Add(bossTerritory);
        //    while (unmarkedTerritories.Count > 0)
        //    {
        //        var currentMarkedTerritory = markedTerritories[markedTerritories.Count - 1];
        //        var minDistance = int.MaxValue;
        //        Territory destination = null;
        //        var minDisUnmarkedTerritoryIndex = -1;
        //        for (int i = 0; i < unmarkedTerritories.Count; i++)
        //        {
        //            var unmarkedTerritory = unmarkedTerritories[i];
        //            var distance = Mathf.Abs(currentMarkedTerritory.WorldCoord.x - unmarkedTerritory.WorldCoord.x) + Mathf.Abs(currentMarkedTerritory.WorldCoord.y - unmarkedTerritory.WorldCoord.y);
        //            if (distance < minDistance)
        //            {
        //                destination = unmarkedTerritory;
        //                minDisUnmarkedTerritoryIndex = i;
        //                minDistance = distance;
        //            }
        //        }

        //        minDistance = int.MaxValue;
        //        Territory departure = null;
        //        foreach (var markedTerritory in markedTerritories)
        //        {
        //            var distance = Mathf.Abs(markedTerritory.WorldCoord.x - destination.WorldCoord.x) + Mathf.Abs(markedTerritory.WorldCoord.y - destination.WorldCoord.y);
        //            if (distance < minDistance)
        //            {
        //                departure = markedTerritory;
        //                minDistance = distance;
        //            }
        //        }

        //        markedTerritories.Add(destination);
        //        unmarkedTerritories.RemoveAt(minDisUnmarkedTerritoryIndex);
        //        var coords = GenerateCoordsOnPathByAStar(departure.WorldCoord, destination.WorldCoord, territorymap);
        //        paths.Add(new Path(departure, destination, coords));
        //        yield return null;
        //    }
        //}



    }
}

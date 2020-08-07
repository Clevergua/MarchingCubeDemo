using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Terrain
{
    public class Island
    {
        public Island(int seed, int worldLength)
        {
            this.seed = seed;
            this.worldLength = worldLength;
        }
        public int seed { get; private set; }
        public int worldLength { get; private set; }
        public int progress { get; private set; }
        public Layer result { get; private set; }
        public string currentOperation { get; private set; }
        public bool isDone { get; private set; } = false;



        internal async void Generate()
        {
            Dictionary<EnvironmentDegree, Biome> environmentDegree2Biome = new Dictionary<EnvironmentDegree, Biome>();

            var length = worldLength * Constants.ChunkLength;

            currentOperation = "正在生成环境图与领地图";
            Environmentmap environmentmap = null;
            Territorymap territorymap = null;
            {
                var environmentmapTask = GenerateEnvironmentalmaps(seed, length, environmentDegree2Biome);

                var necessaryTerritories = new List<Territory>();
                var normalTerritories = new List<Territory>();
                var territorymapTask = GenerateTerritorymap(necessaryTerritories, normalTerritories, length, seed);

                //相当于WaitAll(environmentmapTask,territorymapTask);
                environmentmap = await environmentmapTask;
                territorymap = await territorymapTask;
            }
            progress = 15;

            currentOperation = "正在生成领地内建筑图";
            {
                var tasks = new Task[territorymap.ID2Territory.Count];
                for (int i = 0; i < territorymap.ID2Territory.Count; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        territorymap.ID2Territory[i].GenerateStructuremap(environmentmap, seed);
                    });
                    Task.WaitAll(tasks);
                }
            }
            progress = 20;

            Pathmap pathmap = null;
            currentOperation = "正在生成道路图";
            {
                pathmap = new Pathmap(length, length);
                //在所有领地内生成建筑的道路图
                {
                    var tasks = new List<Task<Pathmap>>();
                    var swCoords = new List<Coord2Int>();
                    foreach (var territory in territorymap.ID2Territory)
                    {
                        var function = new Func<Pathmap>(territory.GeneratePathmap);
                        var swCoord = territorymap.Territory2CenterCoord[territory] - territory.Pivot2Int;
                        tasks.Add(Task.Run(function));
                        swCoords.Add(swCoord);

                    }
                    Task.WaitAll(tasks.ToArray());
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        var task = tasks[i];
                        var swCoord = swCoords[i];
                        var territoryPathmap = task.Result;
                        for (int x = 0; x < territoryPathmap.Length; x++)
                        {
                            for (int z = 0; z < territoryPathmap.Width; z++)
                            {
                                pathmap[x + swCoord.x, z + swCoord.y] = territoryPathmap[x, z];
                            }
                        }
                    }
                }
                //道路连接领地
                {
                    var calculatedTerritories = new List<Territory>();
                    var uncalculatedTerritories = new List<Territory>(territorymap.ID2Territory);
                    calculatedTerritories.Add(uncalculatedTerritories[0]);
                    uncalculatedTerritories.RemoveAt(0);

                    while (uncalculatedTerritories.Count > 0)
                    {
                        //从已经计算的列表中取出最新的作为当前领地
                        var current = calculatedTerritories[calculatedTerritories.Count - 1];
                        //查找距离当前领地最近的领地
                        var minDistance = int.MaxValue;
                        var index = -1;
                        for (int i = 0; i < uncalculatedTerritories.Count; i++)
                        {
                            var c1 = territorymap.Territory2CenterCoord[current];
                            var c2 = territorymap.Territory2CenterCoord[uncalculatedTerritories[i]];
                            var manhattanDistance = Coord2Int.ManhattanDistance(c1, c2);
                            if (manhattanDistance < minDistance)
                            {
                                minDistance = manhattanDistance;
                                index = i;
                            }
                        }
                        var target = uncalculatedTerritories[index];
                        //连接两个领地
                        var coords = Connect2TerritoriesWithPath(current, target, pathmap, territorymap);
                        foreach (var coord in coords)
                        {
                            pathmap[coord.x, coord.y] = true;
                        }
                    }
                }
                progress = 30;

                currentOperation = "正在生成噪声图";
                {

                }
                progress = 50;

                currentOperation = "正在生成地表与种植植物";
                {

                }
                progress = 60;

                currentOperation = "正在生成建筑";
                {

                }
                progress = 70;


                #region 绘制图
                var texture = new Texture2D(length, length, TextureFormat.ARGB32, false);
                var territoryType2Color = new Dictionary<Type, Color>();
                foreach (var item in territorymap.ID2Territory)
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
                            texture.SetPixel(x, y, territoryType2Color[territorymap.ID2Territory[index].GetType()]);
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
        }

        private IReadOnlyList<Coord2Int> Connect2TerritoriesWithPath(Territory territory1, Territory territory2, Pathmap pathmap, Territorymap territorymap)
        {
            var id1 = GetStructureIDClosed2Target(territory1, territorymap.Territory2CenterCoord[territory2], territorymap);
            var id2 = GetStructureIDClosed2Target(territory2, territorymap.Territory2CenterCoord[territory1], territorymap);
            var structure1 = id1 == -1 ? null : territory1.structuremap.ID2Structure[id1];
            var structure2 = id2 == -1 ? null : territory2.structuremap.ID2Structure[id2];
            //使用A*算法生成路径图
            {
                Coord2Int start = Coord2Int.zero;
                if (structure1 == null)
                {
                    start = territorymap.Territory2CenterCoord[territory1];
                }
                else
                {
                    var territorySWCoord = territorymap.Territory2CenterCoord[territory1] - territory1.Pivot2Int;
                    var structureCenterLocalCoord = territory1.structuremap.Structure2SWCoord[structure1] + structure1.Pivot2Int;
                    start = territorySWCoord + structureCenterLocalCoord;
                }
                Coord2Int goal = Coord2Int.zero;
                if (structure2 == null)
                {
                    goal = territorymap.Territory2CenterCoord[territory2];
                }
                else
                {
                    var territorySWCoord = territorymap.Territory2CenterCoord[territory2] - territory2.Pivot2Int;
                    var structureCenterLocalCoord = territory2.structuremap.Structure2SWCoord[structure2] + structure2.Pivot2Int;
                    goal = territorySWCoord + structureCenterLocalCoord;
                }

                var coordOpenSet = new HashSet<Coord2Int>() { start };
                var coord2CameFrom = new Dictionary<Coord2Int, Coord2Int>();
                var coord2GScore = new Dictionary<Coord2Int, int>() { { start, 0 } };
                var coord2FScore = new Dictionary<Coord2Int, int>() { { start, Coord2Int.ManhattanDistance(start, goal) } };

                while (coordOpenSet.Count > 0)
                {
                    //获得最小代价点作为当前点
                    var minFScore = int.MaxValue;
                    var current = Coord2Int.zero;
                    foreach (var item in coordOpenSet)
                    {
                        if (coord2FScore[item] < minFScore)
                        {
                            current = item;
                            minFScore = coord2FScore[item];
                        }
                    }
                    //如果当前为目标则直接返回
                    if (current == goal)
                    {
                        var coords = new List<Coord2Int>();
                        while (coord2CameFrom.ContainsKey(current))
                        {
                            current = coord2CameFrom[current];
                            coords.Add(current);
                        }
                        coords.Reverse();
                        return coords;
                    }
                    else
                    {
                        coordOpenSet.Remove(current);
                        //遍历所有邻居
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                var x = current.x + i;
                                var z = current.y + j;
                                if (i == 0 && j == 0)
                                {
                                    //该点是自身点不是相邻点,排除.
                                }
                                else if (x < 0 || x >= pathmap.Length || z < 0 || z >= pathmap.Width)
                                {
                                    //越界
                                }
                                else
                                {
                                    var neighbor = new Coord2Int(x, z);
                                    var movable = false;

                                    //如果相邻点可走
                                    //这里认为起始和目标领地以及空地可走
                                    if (territorymap[x, z] == -1)
                                    {
                                        //可走
                                    }
                                    else
                                    {
                                        var currentTerritory = territorymap.ID2Territory[territorymap[x, z]];
                                        var localCoord = neighbor - (territorymap.Territory2CenterCoord[currentTerritory] - currentTerritory.Pivot2Int);
                                        var currenStructureID = currentTerritory.structuremap[localCoord.x, localCoord.y];
                                        //此处无建筑可以走
                                        if (currenStructureID == -1)
                                        {
                                            //可走
                                            movable = true;
                                        }
                                        else
                                        {
                                            //除了是出发点建筑或终点建筑的情况外不可以走
                                            if ((currentTerritory == territory1 && currenStructureID == id1) || (currentTerritory == territory2 && currenStructureID == id2))
                                            {
                                                //可走
                                                movable = true;
                                            }
                                            else
                                            {
                                                //不可走
                                            }
                                        }
                                    }
                                    //此处可以走执行操作
                                    if (movable)
                                    {
                                        var tentativeGScore = coord2GScore[current] + 1;
                                        if (!coord2GScore.ContainsKey(neighbor) || tentativeGScore < coord2GScore[neighbor])
                                        {
                                            if (coord2CameFrom.ContainsKey(neighbor))
                                                coord2CameFrom[neighbor] = current;
                                            else
                                                coord2CameFrom.Add(neighbor, current);

                                            if (coord2GScore.ContainsKey(neighbor))
                                                coord2GScore[neighbor] = tentativeGScore;
                                            else
                                                coord2GScore.Add(neighbor, tentativeGScore);

                                            if (coord2FScore.ContainsKey(neighbor))
                                                coord2FScore[neighbor] = tentativeGScore + Coord2Int.ManhattanDistance(neighbor, goal);
                                            else
                                                coord2FScore.Add(neighbor, tentativeGScore + Coord2Int.ManhattanDistance(neighbor, goal));

                                            if (!coordOpenSet.Contains(neighbor))
                                            {
                                                coordOpenSet.Add(neighbor);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //相邻位置不可移动,排除.
                                    }
                                }
                            }
                        }
                    }
                }
                throw new Exception("Open set is empty but goal was never reached!");
            }
        }
        //获得距离目标最近的建筑ID,如果没有择返回-1
        private int GetStructureIDClosed2Target(Territory territory, Coord2Int target, Territorymap territorymap)
        {
            if (territory.structuremap.ID2Structure.Count > 0)
            {
                int result = -1;
                var minDistance = int.MaxValue;
                for (int i = 0; i < territory.structuremap.ID2Structure.Count; i++)
                {
                    var structure = territory.structuremap.ID2Structure[i];
                    var localStructureSWCoord = territory.structuremap.Structure2SWCoord[structure];
                    var worldPos = (localStructureSWCoord + structure.Pivot2Int) + (territorymap.Territory2CenterCoord[territory] - new Coord2Int(territory.Range, territory.Range));
                    var distance = Coord2Int.ManhattanDistance(worldPos, target);
                    if (distance < minDistance)
                    {
                        result = i;
                    }
                }
                return result;
            }
            else
            {
                return -1;
            }
        }

        private async Task<Environmentmap> GenerateEnvironmentalmaps(int seed, int length, IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome)
        {
            var environmentmap = new Environmentmap(length, length, environmentDegree2Biome);
            await Task.Run(() =>
            {
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
                }
            });
            return environmentmap;
        }
        private async Task<Territorymap> GenerateTerritorymap(List<Territory> necessaryTerritories, List<Territory> normalTerritories, int length, int seed)
        {
            Territorymap territorymap = new Territorymap(length, length);
            await Task.Run(() =>
            {
                //填充必要领地
                {
                    var maxTimes = 8;
                    //根据范围进行排序
                    necessaryTerritories.Sort((l, r) => { return r.Range - l.Range; });
                    var times = 0;
                    while (!TrySetNecessaryTerritories(territorymap, necessaryTerritories, seed + times))
                    {
                        times++;
                        if (times > maxTimes)
                        {
                            throw new Exception("Too many attempts when generating necessary territory");
                        }
                    }
                }
                //填充非必要领地
                {
                    var maxTimes = 4;
                    //根据范围进行排序
                    normalTerritories.Sort((l, r) => { return r.Range - l.Range; });
                    for (int i = 0; i < normalTerritories.Count; i++)
                    {
                        var territory = normalTerritories[i];
                        for (int j = 0; j < maxTimes; j++)
                        {
                            var rx = Mathf.Abs(RNG.Random1(j, seed + i * 487) % territorymap.Length);
                            var rz = Mathf.Abs(RNG.Random1(rx + j, seed + i * 511) % territorymap.Width);
                            var centerCoord = new Coord2Int(rx, rz);
                            var result = territorymap.TryAddTerritory(centerCoord, territory);
                            if (result) { break; }
                        }
                    }
                }
            });
            return territorymap;
        }
        private bool TrySetNecessaryTerritories(Territorymap territorymap, IReadOnlyList<Territory> necessaryTerritories, int seed)
        {
            var maxTimes = 32;
            territorymap.Reset();
            for (int i = 0; i < necessaryTerritories.Count; i++)
            {
                var territory = necessaryTerritories[i];
                var times = 0;
                while (true)
                {
                    times++;
                    if (times < maxTimes)
                    {
                        var rx = RNG.Random1(times, seed + i);
                        var ry = RNG.Random1(rx + times, seed + i);
                        var centerCoord = new Coord2Int(rx, ry);
                        var result = territorymap.TryAddTerritory(centerCoord, territory);
                        if (result) { break; }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
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

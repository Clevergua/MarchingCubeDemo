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
        public static readonly int VerticalChunkCount = 16;
        public static readonly int MinNormalTerritoryCount = 2;
        public static readonly int MaxNormalTerritoryCount = 4;
        public static readonly int HeightNoiseImpactRange = 31;

        public Island(int seed, int worldLength)
        {
            this.seed = seed;
            this.worldLength = worldLength;
            length = worldLength * Constants.ChunkLength;
        }
        public int seed { get; private set; }
        public int worldLength { get; private set; }

        public int length { get; private set; }

        public int progress { get; private set; }
        public Layer result { get; private set; }
        public string currentOperation { get; private set; }
        public bool isDone { get; private set; } = false;



        public async Task Generate()
        {
            Dictionary<EnvironmentDegree, Biome> environmentDegree2Biome = new Dictionary<EnvironmentDegree, Biome>();

            #region 生成二维信息
            currentOperation = "正在生成环境图与领地图";
            Debug.Log(currentOperation);
            Environmentmap environmentmap = null;
            Territorymap territorymap = null;
            {
                var environmentmapTask = GenerateEnvironmentalmaps(seed, length, environmentDegree2Biome);

                var necessaryTerritories = new List<Territory>()
                {
                    new AdventurerCampTerritory(),
                };
                var normalTerritories = new List<Territory>()
                {
                     new AdventurerCampTerritory(),
                     new AdventurerCampTerritory(),
                     new AdventurerCampTerritory(),
                     new AdventurerCampTerritory(),
                     new AdventurerCampTerritory(),
                     new AdventurerCampTerritory(),
                };
                var territorymapTask = GenerateTerritorymap(necessaryTerritories, normalTerritories, length, seed);

                environmentmap = await environmentmapTask;
                territorymap = await territorymapTask;
            }
            progress = 15;

            currentOperation = "正在生成领地内建筑图";
            Debug.Log(currentOperation);
            {
                var tasks = new List<Task>();
                foreach (var territory in territorymap.ID2Territory)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        territory.GenerateStructuremap(environmentmap, seed);
                    }));
                }
                await Task.WhenAll(tasks.ToArray());
            }
            progress = 20;


            Pathmap pathmap = null;
            currentOperation = "正在生成道路图";
            Debug.Log(currentOperation);
            {
                pathmap = new Pathmap(length, length);
                var tasks = new Task[2];
                //在所有领地内生成建筑的道路图
                {
                    tasks[0] = GenerateInternalPathmapForEachTerritory(pathmap, territorymap);
                }
                //道路连接领地
                {
                    tasks[1] = ConnectTerritoriesWithPath(pathmap, territorymap);
                }
                await Task.WhenAll(tasks);
            }
            progress = 30;
            #endregion

            #region 生成三维图
            currentOperation = "正在生成噪声图";
            Debug.Log(currentOperation);
            {
                var coord2NoiseFactor = new Dictionary<Coord3Int, float>();
                await Task.Run(() => { GenerateStructureNoiseFactors(coord2NoiseFactor, territorymap, environmentmap); });
                await Task.Run(() => { GeneratePathNoiseFactors(coord2NoiseFactor, pathmap, environmentmap); });
                var noisemap = await GenerateNoisemap(coord2NoiseFactor, environmentmap);
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
            #endregion

            #region 绘制二维信息图
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
                        texture.SetPixel(x, y, Color.black);
                    }
                    else
                    {
                        texture.SetPixel(x, y, territoryType2Color[territorymap.ID2Territory[index].GetType()]);
                        var curTerritory = territorymap.ID2Territory[index];
                        var structuremap = curTerritory.structuremap;
                        var localCoord = new Coord2Int(x, y) - (curTerritory.IslandSWCoord);
                        if (structuremap[localCoord.x, localCoord.y] != -1)
                        {
                            texture.SetPixel(x, y, Color.grey);
                        }
                    }
                    var b = pathmap[x, y];
                    if (b)
                    {
                        texture.SetPixel(x, y, Color.white);
                    }
                }
            }
            texture.Apply();
            byte[] bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes($"{Application.dataPath}/map.png", bytes);
            #endregion

            await Task.Delay(0);
            progress = 100;
            isDone = true;
        }

        private async Task<float[,,]> GenerateNoisemap(Dictionary<Coord3Int, float> coord2NoiseFactor, Environmentmap environmentmap)
        {
            var verticalLength = 2 * HeightNoiseImpactRange + 1;
            var noisemap = new float[length, verticalLength, length];
            await Task.Run(() =>
            {
                for (int x = 0; x < length; x++)
                {
                    for (int z = 0; z < length; z++)
                    {
                        var h = environmentmap.GetBaseheight(x, z);
                        for (int v = 0; v < verticalLength; v++)
                        {
                            var density = 0.0023f;
                            var y = h + v - HeightNoiseImpactRange;
                            var coord = new Coord3Int(x, y, z);
                            var value = PerlinNoise.SuperimposedOctave3D(seed, x * density, y * density, z * density, 2);
                            if (coord2NoiseFactor.ContainsKey(coord))
                            {
                                noisemap[x, v, z] = value * coord2NoiseFactor[coord];
                            }
                            else
                            {
                                noisemap[x, v, z] = value;
                            }
                        }
                    }
                }
            });
            return noisemap;
        }

        private void GeneratePathNoiseFactors(Dictionary<Coord3Int, float> coord2NoiseFactor, Pathmap pathmap, Environmentmap environmentmap)
        {
            var maxRangeSquare = Pathmap.PathRange * Pathmap.PathRange;
            for (int ix = 0; ix < pathmap.Length; ix++)
            {
                for (int iz = 0; iz < pathmap.Width; iz++)
                {
                    var h = environmentmap.GetBaseheight(ix, iz);
                    if (pathmap[ix, iz])
                    {
                        for (int x = ix - Pathmap.PathRange; x <= ix + Pathmap.PathRange; x++)
                        {
                            for (int z = iz - Pathmap.PathRange; z <= iz + Pathmap.PathRange; z++)
                            {
                                for (int y = h - Pathmap.PathRange; y <= h + Pathmap.PathRange; y++)
                                {
                                    var rangeSquare = (x - ix) * (x - ix) + (z - iz) * (z - iz) + (y - h) * (y - h);
                                    var factor = (float)rangeSquare / maxRangeSquare;
                                    if (factor > 1)
                                    {
                                        //抛弃
                                    }
                                    else
                                    {
                                        var coord = new Coord3Int(x, y, z);
                                        if (coord2NoiseFactor.ContainsKey(coord))
                                        {
                                            if (factor < coord2NoiseFactor[coord])
                                            {
                                                coord2NoiseFactor[coord] = factor;
                                            }
                                            else
                                            {
                                                //抛弃
                                            }
                                        }
                                        else
                                        {
                                            coord2NoiseFactor.Add(coord, factor);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void GenerateStructureNoiseFactors(Dictionary<Coord3Int, float> coord2NoiseFactor, Territorymap territorymap, Environmentmap environmentmap)
        {
            //为每个建筑生成噪声影响值
            foreach (var territory in territorymap.ID2Territory)
            {
                foreach (var structure in territory.structuremap.ID2Structure)
                {
                    var worldCoord = structure.TerritoryCoord + territory.IslandSWCoord;
                    var r = (structure.Length - structure.Pivot3Int.x) + structure.Height + (structure.Width - structure.Pivot3Int.z);
                    var maxRangeSquare = (structure.Length - structure.Pivot3Int.x) * (structure.Length - structure.Pivot3Int.x) + structure.Height * structure.Height + (structure.Width - structure.Pivot3Int.z) * (structure.Width - structure.Pivot3Int.z);
                    for (int x = worldCoord.x - r; x <= worldCoord.x + r; x++)
                    {
                        for (int z = worldCoord.y - r; z <= worldCoord.y + r; z++)
                        {
                            var h = environmentmap.GetBaseheight(worldCoord.x, worldCoord.y);
                            for (int y = h - r; y <= h + r; y++)
                            {
                                var curCoord = new Coord3Int(x, y, z);
                                //在半径处Factor = 1在中心的时候Factor = 0
                                var rangeSquare = (x - worldCoord.x) * (x - worldCoord.x) + (z - worldCoord.y) * (z - worldCoord.y) + (y - h) * (y - h);
                                var factor = (float)rangeSquare / maxRangeSquare;
                                if (factor > 1)
                                {
                                    //抛弃
                                }
                                else
                                {
                                    if (coord2NoiseFactor.ContainsKey(curCoord))
                                    {
                                        if (factor < coord2NoiseFactor[curCoord])
                                        {
                                            coord2NoiseFactor[curCoord] = factor;
                                        }
                                        else
                                        {
                                            //抛弃
                                        }
                                    }
                                    else
                                    {
                                        coord2NoiseFactor.Add(curCoord, factor);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private async Task ConnectTerritoriesWithPath(Pathmap pathmap, Territorymap territorymap)
        {
            var calculatedTerritories = new List<Territory>();
            var uncalculatedTerritories = new List<Territory>(territorymap.ID2Territory);
            calculatedTerritories.Add(uncalculatedTerritories[0]);
            uncalculatedTerritories.RemoveAt(0);
            var tasks = new List<Task>();
            while (uncalculatedTerritories.Count > 0)
            {
                //从已经计算的列表中取出最新的作为当前领地
                var currentTerritory = calculatedTerritories[calculatedTerritories.Count - 1];
                //查找距离当前领地最近的领地作为目标(target)
                var minDistance = int.MaxValue;
                var index = -1;
                for (int i = 0; i < uncalculatedTerritories.Count; i++)
                {
                    var c1 = currentTerritory.IslandCoord;
                    var c2 = uncalculatedTerritories[i].IslandCoord;
                    var manhattanDistance = Coord2Int.ManhattanDistance(c1, c2);
                    if (manhattanDistance < minDistance)
                    {
                        minDistance = manhattanDistance;
                        index = i;
                    }
                }
                var targetTerritory = uncalculatedTerritories[index];
                //连接两个领地
                tasks.Add(Task.Run(() =>
                {
                    var coords = Connect2TerritoriesWithPath(currentTerritory, targetTerritory, pathmap, territorymap);
                    foreach (var coord in coords)
                    {
                        var territoryID = territorymap[coord.x, coord.y];
                        if (territoryID == -1)
                        {
                            pathmap[coord.x, coord.y] = true;
                        }
                        else
                        {
                            var t = territorymap.ID2Territory[territoryID];
                            var localCoord = coord - t.IslandSWCoord;
                            if (t.structuremap[localCoord.x, localCoord.y] == -1)
                            {
                                pathmap[coord.x, coord.y] = true;
                            }
                            else
                            {
                                //Do nothing..
                            }
                        }
                    }
                }));
                calculatedTerritories.Add(targetTerritory);
                uncalculatedTerritories.RemoveAt(index);
            }
            await Task.WhenAll(tasks.ToArray());
        }
        private async Task GenerateInternalPathmapForEachTerritory(Pathmap pathmap, Territorymap territorymap)
        {
            var territoryCount = territorymap.ID2Territory.Count;
            var tasks = new List<Task>();
            var swCoords = new List<Coord2Int>();
            foreach (var territory in territorymap.ID2Territory)
            {
                tasks.Add(Task.Run(() =>
                {
                    var territoryPathmap = territory.GeneratePathmap();
                    for (int x = 0; x < territoryPathmap.Length; x++)
                    {
                        for (int z = 0; z < territoryPathmap.Width; z++)
                        {
                            pathmap[x + territory.IslandSWCoord.x, z + territory.IslandSWCoord.y] = territoryPathmap[x, z];
                        }
                    }
                }));
            }
            await Task.WhenAll(tasks);
        }
        private IReadOnlyList<Coord2Int> Connect2TerritoriesWithPath(Territory territory1, Territory territory2, Pathmap pathmap, Territorymap territorymap)
        {
            var id1 = GetStructureIDClosed2Target(territory1, territory2.IslandCoord);
            var id2 = GetStructureIDClosed2Target(territory2, territory1.IslandCoord);
            var structure1 = id1 == -1 ? null : territory1.structuremap.ID2Structure[id1];
            var structure2 = id2 == -1 ? null : territory2.structuremap.ID2Structure[id2];
            //使用A*算法生成路径图
            {
                Coord2Int start = Coord2Int.zero;
                if (structure1 == null)
                {
                    start = territory1.IslandCoord;
                }
                else
                {
                    start = territory1.IslandSWCoord + structure1.TerritoryCoord;
                }
                Coord2Int goal = Coord2Int.zero;
                if (structure2 == null)
                {
                    goal = territory2.IslandCoord;
                }
                else
                {
                    goal = territory2.IslandSWCoord + structure2.TerritoryCoord;
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
                                        movable = true;
                                    }
                                    else
                                    {
                                        var currentTerritory = territorymap.ID2Territory[territorymap[x, z]];
                                        var localCoord = neighbor - currentTerritory.IslandSWCoord;
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
                Debug.LogError("Open set is empty but goal was never reached!");
                //throw new Exception("Open set is empty but goal was never reached!");
                return new List<Coord2Int>();
            }
        }
        /// <summary>
        /// 获得距离目标最近的建筑ID,如果没有择返回-1
        /// </summary>
        /// <param name="territory"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int GetStructureIDClosed2Target(Territory territory, Coord2Int target)
        {
            if (territory.structuremap.ID2Structure.Count > 0)
            {
                int result = -1;
                var minDistance = int.MaxValue;
                for (int i = 0; i < territory.structuremap.ID2Structure.Count; i++)
                {
                    var structure = territory.structuremap.ID2Structure[i];
                    var islandCoord = structure.TerritoryCoord + territory.IslandSWCoord;
                    var distance = Coord2Int.ManhattanDistance(islandCoord, target);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
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
            var tasks = new Task[3];
            //生成高度图
            var baseheightmapTask = Task.Run(() =>
            {
                var map = new int[length, length];
                for (int x = 0; x < length; x++)
                {
                    for (int z = 0; z < length; z++)
                    {
                        var heightNoiseDensity = 0.007f;
                        var heightNoise = PerlinNoise.PerlinNoise2D(seed + 1232, x * heightNoiseDensity, z * heightNoiseDensity) * 1.578f * 0.5f + 0.5f;
                        map[x, z] = (int)(Mathf.Lerp(Environmentmap.MinBaseHeight, Environmentmap.MaxBaseHeight, heightNoise));
                    }
                }
                return map;
            });

            var basetemperaturemapTask = Task.Run(() =>
            {
                var map = new int[length, length];
                for (int x = 0; x < length; x++)
                {
                    for (int z = 0; z < length; z++)
                    {
                        var temperatureNoiseDensity = 0.003f;
                        var temperatureNoise = PerlinNoise.PerlinNoise2D(seed + 8674, x * temperatureNoiseDensity, z * temperatureNoiseDensity) * 1.578f;
                        var t1 = temperatureNoise * temperatureNoise;
                        temperatureNoise *= 1.4f - 0.4f * t1;

                        temperatureNoise = temperatureNoise * 0.5f + 0.5f;
                        map[x, z] = (int)(Mathf.Lerp(Environmentmap.MinTemperature, Environmentmap.MaxTemperature, temperatureNoise));
                    }
                }
                return map;
            });
            var basehumiditymapTask = Task.Run(() =>
            {
                var map = new int[length, length];
                for (int x = 0; x < length; x++)
                {
                    for (int z = 0; z < length; z++)
                    {
                        var humidityNoiseDensity = 0.003f;
                        var humidityNoise = PerlinNoise.PerlinNoise2D(seed + 96, x * humidityNoiseDensity, z * humidityNoiseDensity) * 1.578f;
                        var t2 = humidityNoise * humidityNoise;
                        humidityNoise *= 1.4f - 0.4f * t2;

                        humidityNoise = humidityNoise * 0.5f + 0.5f;
                        map[x, z] = (int)(Mathf.Lerp(Environmentmap.MinHumidity, Environmentmap.MaxHumidity, humidityNoise));
                    }
                }
                return map;
            });

            var baseheightmap = await baseheightmapTask;
            var basetemperaturemap = await basetemperaturemapTask;
            var basehumiditymap = await basehumiditymapTask;
            return new Environmentmap(baseheightmap, basetemperaturemap, basehumiditymap, environmentDegree2Biome);

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
                        var rx = RNG.Random1(times, seed + i) % territorymap.Length;
                        var ry = RNG.Random1(rx + times, seed + i) % territorymap.Length;
                        rx = rx > 0 ? rx : -rx;
                        ry = ry > 0 ? ry : -ry;
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
        private async Task NoiseBlockmap(byte[,,] blockmap, int[,] heightmap, int[,] territorymap, IReadOnlyList<Territory> id2Territory, IReadOnlyDictionary<Coord3Int, int> coord2MinDistanceFromPath, int seed)
        {
            var length = blockmap.GetLength(0);
            var height = blockmap.GetLength(1);

            byte entity = 1;
            byte pit = 2;


            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    var curHeight = heightmap[x, z];
                    for (int y = 0; y < height; y++)
                    {
                        //使用时候factor范围为0-1
                        //factor * noise
                        var currentCoord = new Coord3Int(x, y, z);

                        //高度差为0的时:heightFactor = 1
                        //高度差达到NoiseImpactRange时:factor = 0
                        //更大差值时候:heightFactor < 0
                        var heightDifference = Mathf.Abs(y - curHeight);
                        var heightFactor = ((float)HeightNoiseImpactRange - heightDifference) / HeightNoiseImpactRange;
                        //高度噪声倍率: 1.96 ~ 0.16
                        //减少悬空块的产生
                        var heightNoiseMagnification = heightFactor + 0.4f;
                        heightNoiseMagnification *= heightNoiseMagnification;


                        //在领地中心为:territoryFactor = 0;
                        //距离领地距离达到Range时:territoryFactor = 1;
                        //更远距离时候:territoryFactor > 1;
                        var territoryIndex = territorymap[x, z];
                        var territoryFactor = 0f;
                        if (territoryIndex == -1)
                        {
                            territoryFactor = 1;
                        }
                        else
                        {
                            var territory = id2Territory[territoryIndex];
                            var territoryRange = territory.Range;
                            //var territoryCenter = territory.WorldCoord;
                            //var disSquare = (x - territoryCenter.x) * (x - territoryCenter.x) + (y - curHeight) * (y - curHeight) + (z - territoryCenter.y) * (z - territoryCenter.y);
                            //territoryFactor = (float)disSquare / (territoryRange * territoryRange);
                        }


                        //通过coord2MinDistanceFromPath查找并影响权重
                        //距离道路为0时:pathFactor = 0
                        //距离道路为Range时:pathFactor = 1
                        //超出距离时:pathFactor = 1
                        var pathFactor = 0f;
                        if (coord2MinDistanceFromPath.ContainsKey(currentCoord))
                        {
                            //dis最小值为0 最大值Constants.PathRange
                            var dis = coord2MinDistanceFromPath[currentCoord];
                            pathFactor = (float)dis / Pathmap.PathRange;
                            pathFactor *= pathFactor;
                        }
                        else
                        {
                            pathFactor = 1;
                        }

                        //获取最小值的factory
                        var factor = float.MaxValue;
                        var factors = new float[] { heightFactor, territoryFactor, pathFactor };
                        foreach (var f in factors) { if (f < factor) factor = f; }
                        factor = Mathf.Clamp(factor, 0, 1);

                        if (y <= curHeight)
                        {
                            blockmap[x, y, z] = entity;
                        }
                        if (factor > 0)
                        {
                            var noiseDensity = 0.03f;
                            var noise = PerlinNoise.SuperimposedOctave3D(seed + 2213, x * noiseDensity, y * noiseDensity, z * noiseDensity, 2) * 0.666f;
                            noise *= heightNoiseMagnification;
                            noise *= factor;
                            if (noise > 0.1f)
                            {
                                blockmap[x, y, z] = entity;
                            }
                            else if (noise < -0.2f && blockmap[x, y, z] == 1)
                            {
                                blockmap[x, y, z] = pit;
                            }
                        }
                    }
                }
            }
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

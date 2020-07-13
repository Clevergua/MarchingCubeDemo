using Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Terrain
{
    public class TerrainGenerator
    {
        private int previousRandomNum;

        public Layer CreateLayer(int seed, int worldLength)
        {
            var length = worldLength * Constants.ChunkLength;
            var height = Constants.WorldHeight * Constants.ChunkLength;

            //高度图
            var heightmap = new int[length, length];
            //温度图
            var temperaturemap = new int[length, length];
            //湿度图
            var humiditymap = new int[length, length];

            FillEnvironmentalmaps(seed, length, heightmap, temperaturemap, humiditymap);
            //领地图
            var territorymap = new int[length, length];
            //领地表
            var id2Territory = new List<Territory>();

            var territorySeed = seed;
            while (!TryFillTerritorymap(territorySeed, territorymap, id2Territory))
            {
                territorySeed++;
                if (territorySeed - seed + 1 > 4)
                {
                    throw new Exception($"Try to fill the territory too many times");
                }
            }
            var times = territorySeed - seed + 1;
            Debug.Log($"Try to fill the territory {times} times");

            //路径信息
            var paths = GeneratePaths(id2Territory, territorymap);
            var coord2MinDistanceFromPath = GetCoord2MinDistanceFromPath(paths, length, height, heightmap);

            var blockmap = new int[length, height, length];
            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    var curHeight = heightmap[x, z];
                    for (int y = 0; y < height; y++)
                    {
                        //使用时候factor范围为0-1

                        //高度差为0的时:factor = 1
                        //高度差达到NoiseImpactRange时:factor = 0
                        //更大差值时候:factor < 0
                        var heightDifference = Mathf.Abs(y - curHeight);
                        var heightFactor = ((float)Constants.NoiseImpactRange - heightDifference) / Constants.NoiseImpactRange;

                        //在领地中心为:territoryFactor = 0;
                        //距离领地距离达到Range时:territoryFactor = 1;
                        //更远距离时候:territoryFactor > 1
                        var territory = id2Territory[territorymap[x, z]];
                        var territoryRange = territory.Range;
                        var territoryCenter = territory.CenterCoord;
                        var disSquare = (x - territoryCenter.x) * (x - territoryCenter.x) + (y - curHeight) * (y - curHeight) + (z - territoryCenter.y) * (z - territoryCenter.y);
                        var territoryFactor = (float)disSquare / (territoryRange * territoryRange);


                        //通过coord2MinDistanceFromPath查找并影响权重


                    }
                }
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
                        //if (pathmap[x, y] != -1)
                        //{
                        //    texture.SetPixel(x, y, Color.green);
                        //}
                        //else
                        //{
                        var c = new Color((float)temperaturemap[x, y] / 100, 0, 0);
                        texture.SetPixel(x, y, c);
                        //}
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

        private IReadOnlyDictionary<Coord3Int, int> GetCoord2MinDistanceFromPath(IReadOnlyList<Path> paths, int length, int height, int[,] heightmap)
        {
            var coord2MinDistanceFromPath = new Dictionary<Coord3Int, int>();
            for (int i = 0; i < paths.Count; i++)
            {
                var path = paths[i];
                foreach (var coord2 in path.Coords)
                {
                    var center = new Coord3Int(coord2.x, heightmap[coord2.x, coord2.y], coord2.y);

                    //限制min,max避免越界
                    var minx = center.x - Constants.PathRange < 0 ? 0 : center.x - Constants.PathRange;
                    var miny = center.y - Constants.PathRange < 0 ? 0 : center.y - Constants.PathRange;
                    var minz = center.z - Constants.PathRange < 0 ? 0 : center.z - Constants.PathRange;

                    var maxx = center.x + Constants.PathRange < length ? center.x + Constants.PathRange : length - 1;
                    var maxy = center.y + Constants.PathRange < height ? center.y + Constants.PathRange : height - 1;
                    var maxz = center.z + Constants.PathRange < length ? center.z + Constants.PathRange : length - 1;

                    for (int x = minx; x <= maxx; x++)
                    {
                        for (int y = miny; y < maxy; y++)
                        {
                            for (int z = minz; z < maxz; z++)
                            {
                                var current = new Coord3Int(x, y, z);
                                var distance = ManhattanDistance3D(center, current);
                                if (distance < Constants.PathRange)
                                {
                                    if (coord2MinDistanceFromPath.ContainsKey(current))
                                    {
                                        if (distance < coord2MinDistanceFromPath[current])
                                        {
                                            coord2MinDistanceFromPath[current] = distance;
                                        }
                                        else
                                        {
                                            //较大值抛弃
                                        }
                                    }
                                    else
                                    {
                                        coord2MinDistanceFromPath.Add(current, distance);
                                    }
                                }
                                else
                                {
                                    //范围外部的抛弃
                                }
                            }
                        }
                    }
                }
            }
            return coord2MinDistanceFromPath;
        }

        private IReadOnlyList<Coord2Int> GenerateCoordsOnPathByAStar(Coord2Int start, Coord2Int goal, int[,] territorymap)
        {
            var coordOpenSet = new HashSet<Coord2Int>() { start };
            var coord2CameFrom = new Dictionary<Coord2Int, Coord2Int>();
            var coord2GScore = new Dictionary<Coord2Int, int>() { { start, 0 } };
            var coord2FScore = new Dictionary<Coord2Int, int>() { { start, ManhattanDistance2D(start, goal) } };

            var startTerritoryIndex = territorymap[start.x, start.y];
            var goalTerritoryIndex = territorymap[goal.x, goal.y];
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
                            else if (x < 0 || x >= territorymap.GetLength(0) || z < 0 || z >= territorymap.GetLength(1))
                            {
                                //越界
                            }
                            else
                            {
                                var neighbor = new Coord2Int(x, z);
                                //如果相邻点可走
                                //这里认为起始和目标领地以及空地可走
                                var neighborTerritoryIndex = territorymap[neighbor.x, neighbor.y];
                                if (neighborTerritoryIndex == -1 || neighborTerritoryIndex == startTerritoryIndex || neighborTerritoryIndex == goalTerritoryIndex)
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
                                            coord2FScore[neighbor] = tentativeGScore + ManhattanDistance2D(neighbor, goal);
                                        else
                                            coord2FScore.Add(neighbor, tentativeGScore + ManhattanDistance2D(neighbor, goal));

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
        private int ManhattanDistance2D(Coord2Int start, Coord2Int goal)
        {
            return Mathf.Abs(start.x - goal.x) + Mathf.Abs(start.y - goal.y);
        }
        private int ManhattanDistance3D(Coord3Int start, Coord3Int goal)
        {
            return Mathf.Abs(start.x - goal.x) + Mathf.Abs(start.y - goal.y) + Mathf.Abs(start.z - goal.z);
        }
        private IReadOnlyList<Path> GeneratePaths(IReadOnlyList<Territory> id2Territory, int[,] territorymap)
        {
            var paths = new List<Path>();

            var markedTerritories = new List<Territory>();
            var unmarkedTerritories = new List<Territory>();
            BossTerritory bossTerritory = null;
            foreach (var t in id2Territory)
            {
                if (t is AdventurerTerritory)
                {
                    markedTerritories.Add(t);
                }
                else
                {
                    if (t is BossTerritory)
                    {
                        bossTerritory = t as BossTerritory;
                    }
                    else
                    {
                        unmarkedTerritories.Add(t);
                    }
                }
            }
            unmarkedTerritories.Add(bossTerritory);
            while (unmarkedTerritories.Count > 0)
            {
                var currentMarkedTerritory = markedTerritories[markedTerritories.Count - 1];
                var minDistance = int.MaxValue;
                Territory destination = null;
                var minDisUnmarkedTerritoryIndex = -1;
                for (int i = 0; i < unmarkedTerritories.Count; i++)
                {
                    var unmarkedTerritory = unmarkedTerritories[i];
                    var distance = Mathf.Abs(currentMarkedTerritory.CenterCoord.x - unmarkedTerritory.CenterCoord.x) + Mathf.Abs(currentMarkedTerritory.CenterCoord.y - unmarkedTerritory.CenterCoord.y);
                    if (distance < minDistance)
                    {
                        destination = unmarkedTerritory;
                        minDisUnmarkedTerritoryIndex = i;
                        minDistance = distance;
                    }
                }

                minDistance = int.MaxValue;
                Territory departure = null;
                foreach (var markedTerritory in markedTerritories)
                {
                    var distance = Mathf.Abs(markedTerritory.CenterCoord.x - destination.CenterCoord.x) + Mathf.Abs(markedTerritory.CenterCoord.y - destination.CenterCoord.y);
                    if (distance < minDistance)
                    {
                        departure = markedTerritory;
                        minDistance = distance;
                    }
                }

                markedTerritories.Add(destination);
                unmarkedTerritories.RemoveAt(minDisUnmarkedTerritoryIndex);
                var coords = GenerateCoordsOnPathByAStar(departure.CenterCoord, destination.CenterCoord, territorymap);
                paths.Add(new Path(departure, destination, coords));
            }
            return paths;
        }
        private bool TryFillTerritorymap(int seed, int[,] territorymap, List<Territory> id2Territory)
        {
            var success = true;
            //重置
            for (int x = 0; x < territorymap.GetLength(0); x++)
            {
                for (int y = 0; y < territorymap.GetLength(0); y++)
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
                territory.CenterCoord = new Coord2Int(cx, cy);

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

using Core;
using System;
using System.Collections.Generic;

namespace Terrain
{
    /// <summary>
    /// 领地
    /// </summary>
    internal abstract class Territory
    {
        public Structuremap structuremap { get; protected set; }
        public abstract int Range { get; }
        public int Length
        {
            get
            {
                return Range * 2 + 1;
            }
        }
        public Coord2Int Pivot2Int
        {
            get
            {
                return new Coord2Int(Range, Range);
            }
        }

        /// <summary>
        /// 根据环境信息和种子生成建筑图
        /// </summary>
        /// <param name="environmentmap"></param>
        /// <param name="seed"></param>
        public abstract void GenerateStructuremap(Environmentmap environmentmap, int seed);
        /// <summary>
        /// 生成局部的道路图,生成之前需要完成建筑图的生成
        /// </summary>
        internal virtual Pathmap GeneratePathmap()
        {
            var map = new Pathmap(structuremap.Length, structuremap.Width);
            var calculatedStructures = new List<Structure>();
            var uncalculatedStructures = new List<Structure>(structuremap.ID2Structure);
            calculatedStructures.Add(uncalculatedStructures[0]);
            uncalculatedStructures.RemoveAt(0);

            while (uncalculatedStructures.Count > 0)
            {
                //从已经计算的列表中取出最新的作为当前建筑
                var current = calculatedStructures[calculatedStructures.Count - 1];
                //查找距离当前建筑最近的建筑
                var minDistance = int.MaxValue;
                var index = -1;
                for (int i = 0; i < uncalculatedStructures.Count; i++)
                {
                    var c1 = structuremap.Structure2SWCoord[current] + current.Pivot2Int;
                    var c2 = structuremap.Structure2SWCoord[uncalculatedStructures[i]] + uncalculatedStructures[i].Pivot2Int;
                    var manhattanDistance = Coord2Int.ManhattanDistance(c1, c2);
                    if (manhattanDistance < minDistance)
                    {
                        minDistance = manhattanDistance;
                        index = i;
                    }
                }
                var target = uncalculatedStructures[index];
                //通过A*生成到目标点的路径
                var coords = GenerateCoordsOnPathByAStar(structuremap.Structure2SWCoord[current] + current.Pivot2Int, structuremap.Structure2SWCoord[target] + target.Pivot2Int, structuremap);
                foreach (var c in coords)
                {
                    if (!map[c.x, c.y] && structuremap[c.x, c.y] == 0)
                    {
                        map[c.x, c.y] = true;
                    }
                }
            }
            return map;
        }
        private IReadOnlyList<Coord2Int> GenerateCoordsOnPathByAStar(Coord2Int start, Coord2Int goal, Structuremap structuremap)
        {
            var coordOpenSet = new HashSet<Coord2Int>() { start };
            var coord2CameFrom = new Dictionary<Coord2Int, Coord2Int>();
            var coord2GScore = new Dictionary<Coord2Int, int>() { { start, 0 } };
            var coord2FScore = new Dictionary<Coord2Int, int>() { { start, Coord2Int.ManhattanDistance(start, goal) } };

            var startIndex = structuremap[start.x, start.y];
            var goalIndex = structuremap[goal.x, goal.y];
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
                            else if (x < 0 || x >= structuremap.Length || z < 0 || z >= structuremap.Width)
                            {
                                //越界
                            }
                            else
                            {
                                var neighbor = new Coord2Int(x, z);
                                //如果相邻点可走
                                //这里认为起始和目标领地以及空地可走
                                var neighborTerritoryIndex = structuremap[neighbor.x, neighbor.y];
                                if (neighborTerritoryIndex == -1 || neighborTerritoryIndex == startIndex || neighborTerritoryIndex == goalIndex)
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
}
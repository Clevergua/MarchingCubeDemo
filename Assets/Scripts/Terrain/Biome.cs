using Core;
using System;
using System.Collections.Generic;

namespace Terrain
{
    internal abstract class Biome
    {
        public static readonly float SafeFactor = 0.5f;
        /// <summary>
        /// 正噪声值:该数值越小更容易生成山峰(取值范围为:0.1`0.5)
        /// </summary>
        internal abstract float PositiveNoise { get; }
        /// <summary>
        /// 负噪声值:该数值越大更容易生成坑洞或水池(取值范围为:-0.5~-0.1)
        /// </summary>
        internal abstract float NegativeNoise { get; }

        /// <summary>
        /// 处理连续形状坐标集合,此阶段为使用液体/石头填充Blockmap的过程.
        /// </summary>
        /// <param name="blockmap"></param>
        /// <param name="shape">形状:False:Concave,True:Convex</param>
        /// <param name="concaveCoordsGroup"></param>
        /// <param name="environmentmap"></param>
        /// <param name="seed"></param>
        internal abstract void ProcessShapeCoords(byte[,,] blockmap, bool shape, HashSet<Coord3Int> coordGroup, Environmentmap environmentmap, int seed);
        /// <summary>
        /// 生成地表分层
        /// </summary>
        /// <param name="blockmap"></param>
        /// <param name="coord2Int"></param>
        /// <param name="environmentmap"></param>
        /// <param name="seed"></param>
        internal abstract void GenerateSurface(byte[,,] blockmap, Coord2Int coord2Int, Environmentmap environmentmap, int seed);
        /// <summary>
        /// 生成植物
        /// </summary>
        /// <param name="blockmap"></param>
        /// <param name="environmentmap"></param>
        /// <param name="seed"></param>
        internal abstract void GeneratePlants(byte[,,] blockmap, Coord2Int coord2Int, IReadOnlyDictionary<Coord3Int, float> coord2NoiseFactor, Environmentmap environmentmap, int seed);
        /// <summary>
        /// 根据输入块的类型,填充一个池子
        /// </summary>
        /// <param name="blockmap"></param>
        /// <param name="pitCoordsGroup"></param>
        /// <param name="heightmap"></param>
        /// <param name="blockType"></param>
        protected void FillPool(byte[,,] blockmap, HashSet<Coord3Int> concaveCoordsGroup, Environmentmap environmentmap, byte blockType)
        {
            var length = blockmap.GetLength(0);
            var height = blockmap.GetLength(1);
            //找到会往水平方向外流的凹洞
            var minHeight = int.MaxValue;
            var processedCoord2D = new HashSet<Coord2Int>();
            foreach (var c in concaveCoordsGroup)
            {
                var coord2D = new Coord2Int(c.x, c.z);
                if (processedCoord2D.Contains(coord2D))
                {
                    //已处理过获得了最小海拔
                }
                else
                {
                    var neighbors = new Coord3Int[]
                    {
                        c + Coord3Int.back,
                        c + Coord3Int.forward,
                        c + Coord3Int.left,
                        c + Coord3Int.right
                    };
                    //遍历水平方向的相邻块
                    foreach (var n in neighbors)
                    {
                        var coord = new Coord3Int(n.x, n.y, n.z);
                        if (n.x < 0 || n.y < 0 || n.z < 0 || n.x >= length || n.y >= height || n.z >= length)
                        {
                            //越界认为为实体
                        }
                        else
                        {
                            if (blockmap[n.x, n.y, n.z] == (byte)BlockType.Air)
                            {
                                var baseHeight = environmentmap.GetBaseheight(c.x, c.z);
                                if (baseHeight < minHeight)
                                {
                                    minHeight = height;
                                    processedCoord2D.Add(coord2D);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            //以下的为指定的类型
            foreach (var c in concaveCoordsGroup)
            {
                if (c.y >= minHeight)
                {
                    blockmap[c.x, c.y, c.z] = (byte)BlockType.Air;
                }
                else
                {
                    blockmap[c.x, c.y, c.z] = blockType;
                }
            }
        }
    }
}


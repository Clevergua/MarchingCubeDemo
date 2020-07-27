using Core;
using System;
using System.Collections.Generic;

namespace Terrain
{
    internal abstract class Biome
    {
        public Biome(StructureFactory structureFactory)
        {
            this.structureFactory = structureFactory ?? throw new ArgumentNullException();
        }
        protected StructureFactory structureFactory;

        internal abstract void ProcessPitCoords(IReadOnlyList<Coord3Int> pitCoordsGroup, byte[,,] blockmap, int[,] heightmap, int seed);
        internal abstract void Growing(byte[,,] blockmap, int x, int z, int seed);
        internal abstract void Planting(byte[,,] blockmap, int x, int z, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, int[,] territorymap, IReadOnlyList<Territory> id2Territory, IReadOnlyDictionary<Coord3Int, int> coord2MinDistanceFromPath, int seed);

        protected void FillPool(byte[,,] blockmap, IReadOnlyList<Coord3Int> pitCoordsGroup, int[,] heightmap, byte blockType)
        {
            var length = blockmap.GetLength(0);
            var height = blockmap.GetLength(1);
            byte pit = 0;
            //找到会往水平方向外流的凹洞
            var minAltitude = int.MaxValue;
            var processedCoord2D = new HashSet<Coord2Int>();
            foreach (var c in pitCoordsGroup)
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
                    foreach (var n in neighbors)
                    {
                        if (n.x < 0 || n.y < 0 || n.z < 0 || n.x >= length || n.y >= height || n.z >= length)
                        {
                            //越界认为为实体
                        }
                        else
                        {
                            if (blockmap[n.x, n.y, n.z] == pit)
                            {
                                if (heightmap[c.x, c.z] < minAltitude)
                                {
                                    minAltitude = heightmap[c.x, c.z];
                                    processedCoord2D.Add(coord2D);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            //以下的为指定的类型
            foreach (var c in pitCoordsGroup)
            {
                if (c.y >= minAltitude)
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


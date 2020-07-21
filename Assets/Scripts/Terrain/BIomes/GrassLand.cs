using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine.UIElements;

namespace Terrain
{
    public class GrassLand : Biome
    {
        internal override IEnumerator Growing(byte[,,] blockmap, int x, int z, int seed)
        {
            var density = 0.007f;
            var noise = (PerlinNoise.PerlinNoise2D(seed, x * density, z * density) + 1) * 0.5f;
            var depthRange = 8;
            var minDepth = 1;
            var topDepth = (int)(noise * depthRange + minDepth);
            var temp = topDepth;
            var height = blockmap.GetLength(1);

            for (int y = height - 1; y >= 0; y--)
            {
                if (blockmap[x, y, z] == (byte)BlockType.Air)
                {
                    temp = topDepth;
                }
                if (blockmap[x, y, z] == (byte)BlockType.Stone && temp > 0)
                {
                    blockmap[x, y, z] = (byte)BlockType.Dirt;
                    temp--;
                }
            }
        }

        internal override void ProcessPitCoords(IReadOnlyList<Coord3Int> pitCoordsGroup, byte[,,] blockmap, int[,] heightmap, int seed)
        {
            var length = blockmap.GetLength(0);
            var height = blockmap.GetLength(1);
            byte pit = 0;
            //填充出不会外流的湖泊或者岩浆湖
            //%10的概率产生空地%5的概率产生岩浆湖%85的概率产生湖泊
            //r: 1~99
            var r = RNG.Random3(pitCoordsGroup[0].x, pitCoordsGroup[0].y, pitCoordsGroup[0].z, seed - 4367) % 50 + 50;
            //空地
            if (r <= 10)
            {
                foreach (var c in pitCoordsGroup)
                {
                    blockmap[c.x, c.y, c.z] = (byte)BlockType.Air;
                }
            }
            //湖泊或岩浆湖
            else
            {
                byte blockType;
                if (r <= 15)
                {
                    blockType = (byte)BlockType.Lava;
                }
                else
                {
                    blockType = (byte)BlockType.Water;
                }
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
                //最小海拔及以上的块位空地
                //以下的为水或者岩浆
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

}


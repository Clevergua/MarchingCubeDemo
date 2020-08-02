using System.Collections.Generic;
using Core;

namespace Terrain
{
    internal class GrassLand : Biome
    {

        internal override void Growing(byte[,,] blockmap, int x, int z, int seed)
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

        internal override void Planting(byte[,,] blockmap, int x, int z, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, int[,] territorymap, IReadOnlyList<Territory> id2Territory, IReadOnlyDictionary<Coord3Int, int> coord2MinDistanceFromPath, int seed)
        {
            var height = blockmap.GetLength(1);
            var r = RNG.Random2(x, z, seed - 223) % 500 + 500;
            for (int y = 0; y < height; y++)
            {
                if (blockmap[x, y, z] == (byte)BlockType.Air && y > 0 && blockmap[x, y - 1, z] == (byte)BlockType.Dirt)
                {
                    if (r < 10)
                    {
                        if (territorymap[x, z] == -1)
                        {
                            //领地内不种树
                        }
                        else
                        {
                            var coord = new Coord3Int(x, y, z);
                            var oak = new Oak(coord, seed);
                            var startPoint = coord - data.XZCenter;
                            if (startPoint.x < 0 || startPoint.x + data.Blockmap.GetLength(0) > blockmap.GetLength(0) ||
                                startPoint.y < 0 || startPoint.y + data.Blockmap.GetLength(1) > blockmap.GetLength(1) ||
                                startPoint.z < 0 || startPoint.z + data.Blockmap.GetLength(2) > blockmap.GetLength(2))
                            {
                                continue;
                            }
                            else
                            {
                                for (int lx = 0; lx < data.Blockmap.GetLength(0); lx++)
                                {
                                    for (int ly = 0; ly < data.Blockmap.GetLength(1); ly++)
                                    {
                                        for (int lz = 0; lz < data.Blockmap.GetLength(2); lz++)
                                        {
                                            var wx = startPoint.x + lx;
                                            var wy = startPoint.y + ly;
                                            var wz = startPoint.z + lz;
                                            if (data.Blockmap[lx, ly, lz] != (byte)BlockType.Air && blockmap[wx, wy, wz] == (byte)BlockType.Air)
                                            {
                                                blockmap[wx, wy, wz] = data.Blockmap[lx, ly, lz];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (r < 600)
                    {
                        blockmap[x, y, z] = (byte)BlockType.Grass;
                    }
                    break;
                }
            }
        }

        internal override void ProcessPitCoords(IReadOnlyList<Coord3Int> pitCoordsGroup, byte[,,] blockmap, int[,] heightmap, int seed)
        {
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
                FillPool(blockmap, pitCoordsGroup, heightmap, blockType);
            }
        }


    }

}


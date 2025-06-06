﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core;

namespace Terrain
{
    internal class GrassLand : Biome
    {
        internal override float PositiveNoise { get => 0.25f; }
        internal override float NegativeNoise { get => -0.15f; }
        internal override void ProcessShapeCoords(byte[,,] blockmap, bool shape, HashSet<Coord3Int> coordGroup, Environmentmap environmentmap, int seed)
        {
            if (shape)
            {
                foreach (var coord in coordGroup)
                {
                    blockmap[coord.x, coord.y, coord.z] = (byte)BlockType.Stone;
                }
            }
            else
            {
                //%2的概率产生岩浆 98%的概率产生湖泊
                var first = coordGroup.First();
                var r = RNG.Random3(first.x, first.y, first.z, seed - 4367) % 50 + 50;
                if (r <= 98)
                {
                    FillPool(blockmap, coordGroup, environmentmap, (byte)BlockType.Water);
                }
                else
                {
                    FillPool(blockmap, coordGroup, environmentmap, (byte)BlockType.Lava);
                }
            }
        }

        internal override void GenerateSurface(byte[,,] blockmap, Coord2Int coord2Int, Environmentmap environmentmap, IReadOnlyDictionary<Coord3Int, float> coord2NoiseFactor, int seed)
        {
            //1~7
            var dirtThickness = RNG.Random2(coord2Int.x, coord2Int.y, seed) % 4 + 4;
            var tempValue = dirtThickness;
            for (int y = blockmap.GetLength(1) - 1; y >= 0; y--)
            {
                var curBlock = blockmap[coord2Int.x, y, coord2Int.y];
                if (curBlock == (byte)BlockType.Stone)
                {
                    if (tempValue > 0)
                    {
                        tempValue--;
                        blockmap[coord2Int.x, y, coord2Int.y] = (byte)BlockType.Dirt;
                    }
                    else
                    {
                        //深层不做处理
                    }
                }
                else if (curBlock == (byte)BlockType.Air)
                {
                    tempValue = dirtThickness;
                }
            }
        }

        internal override void GeneratePlants(byte[,,] blockmap, Coord2Int coord2Int, IReadOnlyDictionary<Coord3Int, float> coord2NoiseFactor, Environmentmap environmentmap, int seed)
        {
            var x = coord2Int.x;
            var z = coord2Int.y;
            var height = blockmap.GetLength(1);
            var r = RNG.Random2(x, z, seed - 223) % 500 + 500;
            for (int y = 0; y < height; y++)
            {
                var coord = new Coord3Int(x, y, z);
                if (blockmap[x, y, z] == (byte)BlockType.Air && y > 0 && blockmap[x, y - 1, z] == (byte)BlockType.Dirt)
                {
                    if (!coord2NoiseFactor.ContainsKey(coord) || (coord2NoiseFactor.ContainsKey(coord) && coord2NoiseFactor[coord] > SafeFactor))
                    {
                        if (r < 5)
                        {
                            var oak = new Oak(coord, seed);
                            var startPoint = coord - new Coord3Int(oak.Pivot2Int.x, 0, oak.Pivot2Int.y);
                            if (startPoint.x < 0 || startPoint.x + oak.Length > blockmap.GetLength(0) ||
                                startPoint.y < 0 || startPoint.y + oak.Width > blockmap.GetLength(1) ||
                                startPoint.z < 0 || startPoint.z + oak.Height > blockmap.GetLength(2))
                            {
                                continue;
                            }

                            for (int lx = 0; lx < oak.Length; lx++)
                            {
                                for (int lz = 0; lz < oak.Width; lz++)
                                {
                                    for (int ly = 0; ly < oak.Height; ly++)
                                    {
                                        var wx = startPoint.x + lx;
                                        var wy = startPoint.y + ly;
                                        var wz = startPoint.z + lz;
                                        if (oak[lx, ly, lz] != (byte)BlockType.Air && blockmap[wx, wy, wz] == (byte)BlockType.Air)
                                        {
                                            blockmap[wx, wy, wz] = oak[lx, ly, lz];
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
        }
    }
}


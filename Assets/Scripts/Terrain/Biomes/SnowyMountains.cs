using UnityEngine;
using System.Collections;
using Core;
using System.Collections.Generic;
using System.Linq;

namespace Terrain
{
    internal class SnowyMountains : Biome
    {
        internal override float PositiveNoise => 0.05f;
        internal override float NegativeNoise => -0.2f;

        internal override void GeneratePlants(byte[,,] blockmap, Coord2Int coord2Int, IReadOnlyDictionary<Coord3Int, float> coord2NoiseFactor, Environmentmap environmentmap, int seed) { }

        internal override void GenerateSurface(byte[,,] blockmap, Coord2Int coord2Int, Environmentmap environmentmap, IReadOnlyDictionary<Coord3Int, float> coord2NoiseFactor, int seed)
        {
            //1~7
            var r1 = RNG.Random2(coord2Int.x, coord2Int.y, seed);
            var r2 = RNG.Random2(coord2Int.x, coord2Int.y, seed + 48);
            var snowThickness = r1 % 4 + 4;
            var dirtThickness = r2 % 4 + 3;
            var sTemp = snowThickness;
            var dTemp = dirtThickness;
            for (int y = blockmap.GetLength(1) - 1; y >= 0; y--)
            {
                var coord = new Coord3Int(coord2Int.x, y, coord2Int.y);
                var curBlock = blockmap[coord2Int.x, y, coord2Int.y];

                if (curBlock == (byte)BlockType.Stone)
                {
                    var canReplaced = coord2NoiseFactor.ContainsKey(coord) && coord2NoiseFactor[coord] < SafeFactor && RNG.Random3(coord.x, coord.y, coord.z, seed) % 50 < -30;
                    if (canReplaced)
                    {
                        blockmap[coord2Int.x, y, coord2Int.y] = (byte)BlockType.Dirt;
                    }
                    else
                    {
                        if (sTemp > 0)
                        {
                            sTemp--;
                            blockmap[coord2Int.x, y, coord2Int.y] = (byte)BlockType.Snow;
                        }
                        else
                        {
                            if (dTemp > 0)
                            {
                                dTemp--;
                                blockmap[coord2Int.x, y, coord2Int.y] = (byte)BlockType.Dirt;
                            }
                            else
                            {
                                //为石头
                            }
                        }
                    }
                }
                else if (curBlock == (byte)BlockType.Air)
                {
                    sTemp = snowThickness;
                    dTemp = dirtThickness;
                }
            }
        }

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
                //%15的概率产生岩浆 85%的概率产生冰湖泊
                var first = coordGroup.First();
                var r = RNG.Random3(first.x, first.y, first.z, seed - 4367) % 50 + 50;
                if (r <= 70)
                {
                    foreach (var coord in coordGroup)
                    {
                        blockmap[coord.x, coord.y, coord.z] = (byte)BlockType.Ice;
                    }
                }
                else
                {
                    FillPool(blockmap, coordGroup, environmentmap, (byte)BlockType.Lava);
                }
            }
        }
    }
}
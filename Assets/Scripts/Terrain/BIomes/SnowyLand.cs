using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace Terrain
{
    public class SnowyLand : Biome
    {
        internal override void Growing(byte[,,] blockmap, int x, int z, int seed)
        {
            var density = 0.007f;
            var noise = (PerlinNoise.PerlinNoise2D(seed, x * density, z * density) + 1) * 0.5f;
            var depthRange = 4;
            var minDepth = 0;
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
                    blockmap[x, y, z] = (byte)BlockType.Snow;
                    temp--;
                }
            }
        }

        internal override void Planting(byte[,,] blockmap, int x, int z, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, int[,] territorymap, IReadOnlyList<Territory> id2Territory, IReadOnlyDictionary<Coord3Int, int> coord2MinDistanceFromPath, int seed)
        {
            
        }

        internal override void ProcessPitCoords(IReadOnlyList<Coord3Int> pitCoordsGroup, byte[,,] blockmap, int[,] heightmap, int seed)
        {
            //%10的概率产生空地%40的概率产生岩浆湖%50概率产生冰块
            //r: 1~99
            var r = RNG.Random3(pitCoordsGroup[0].x, pitCoordsGroup[0].y, pitCoordsGroup[0].z, seed + 4367) % 50 + 50;
            //空地
            if (r <= 10)
            {
                foreach (var c in pitCoordsGroup)
                {
                    blockmap[c.x, c.y, c.z] = (byte)BlockType.Air;
                }
            }
            //岩浆湖
            else if (r < 60)
            {
                FillPool(blockmap, pitCoordsGroup, heightmap, (byte)BlockType.Lava);
            }
            else
            {
                foreach (var c in pitCoordsGroup)
                {
                    blockmap[c.x, c.y, c.z] = (byte)BlockType.Ice;
                }
            }
        }
    }
}


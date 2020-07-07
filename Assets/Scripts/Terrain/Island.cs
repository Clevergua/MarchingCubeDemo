using Core;
using System;
using UnityEngine;

namespace Terrain
{
    public abstract class Island
    {
        internal Coord2Int LocalVerticalCenterBlockCoord
        {
            get
            {
                var v = Constants.ChunkLength * Length / 2;
                return new Coord2Int(v, v);
            }
        }
        internal Coord2Int WorldVerticalCenterBlockCoord
        {
            get
            {
                var worldCenterVerticalCoord = LocalVerticalCenterBlockCoord + new Coord2Int(SouthwestChunkCoord.x * Constants.ChunkLength, SouthwestChunkCoord.y * Constants.ChunkLength);
                return worldCenterVerticalCoord;
            }
        }
        internal Coord2Int SouthwestChunkCoord { get; set; }
        internal abstract int Length { get; }

        internal int[,,] GetVerticalBlockmap(Coord2Int verticalChunkCoord, int seed)
        {
            if (VerticalChunkCoordIsOutOfIslandRange(verticalChunkCoord))
            {
                throw new Exception($"Chunk coordinate:({verticalChunkCoord.x},{verticalChunkCoord.y})is out of {GetType()} island range");
            }
            else
            {
                var hieghtmap = GenerateHeightmap(verticalChunkCoord, seed);
                return GenerateVerticalBlockmap(verticalChunkCoord, seed, hieghtmap);
            }
        }

        private int[,] GenerateHeightmap(Coord2Int verticalChunkCoord, int seed)
        {
            var heightmap = new int[Constants.ChunkLength, Constants.ChunkLength];
            for (int x = 0; x < Constants.ChunkLength; x++)
            {
                for (int z = 0; z < Constants.ChunkLength; z++)
                {
                    var worldVerticalBlocksCoord = new Coord2Int(verticalChunkCoord.x * Constants.ChunkLength + x, verticalChunkCoord.y * Constants.ChunkLength + z);
                    var heightSampleDensity = 0.0017f;
                    //0~1
                    var noiseValue = PerlinNoise.PerlinNoise2D(seed, worldVerticalBlocksCoord.x * heightSampleDensity, worldVerticalBlocksCoord.y * heightSampleDensity) * 0.5f + 0.5f;
                    var minHeight = 64;
                    var maxHeight = 128;
                    var height = (int)Mathf.Lerp(minHeight, maxHeight, noiseValue);
                    heightmap[x, z] = height;

                }
            }
            return heightmap;
        }

        protected abstract int[,,] GenerateVerticalBlockmap(Coord2Int worldChunkCoord, int seed, int[,] hieghtmap);
        private bool VerticalChunkCoordIsOutOfIslandRange(Coord2Int chunkCoord)
        {
            var x = chunkCoord.x;
            var z = chunkCoord.y;
            var result = x < SouthwestChunkCoord.x || z < SouthwestChunkCoord.y || x > SouthwestChunkCoord.x + Length || z > SouthwestChunkCoord.y + Length;
            return result;
        }
    }
}
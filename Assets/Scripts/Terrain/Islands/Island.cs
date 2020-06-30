using Core.Math;
using System;

namespace Terrain
{
    public abstract class Island
    {
        internal Coord2Int LocalCenterCoord
        {
            get
            {
                var v = Constants.ChunkLength * Length / 2;
                return new Coord2Int(v, v);
            }
        }
        internal Coord2Int SouthwestChunkCoord { get; set; }
        internal abstract int Length { get; }

        internal int[][,,] GetVerticalBlockmaps(Coord2Int verticalChunkCoord, int seed)
        {
            if (VerticalChunkCoordIsOutOfIslandRange(verticalChunkCoord))
            {
                throw new Exception($"Chunk coordinate:({verticalChunkCoord.x},{verticalChunkCoord.y})is out of {GetType()} island range");
            }
            else
            {
                GenerateGenerateRawTerrainData();
                return GenerateCoord2BlockIDOfChunk(verticalChunkCoord, seed);
            }
        }

        protected abstract int[][,,] GenerateCoord2BlockIDOfChunk(Coord2Int worldChunkCoord, int seed);
        private bool VerticalChunkCoordIsOutOfIslandRange(Coord2Int chunkCoord)
        {
            var x = chunkCoord.x;
            var z = chunkCoord.y;
            var result = x < SouthwestChunkCoord.x || z < SouthwestChunkCoord.y || x > SouthwestChunkCoord.x + Length || z > SouthwestChunkCoord.y + Length;
            return result;
        }
    }
}
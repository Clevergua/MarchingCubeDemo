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
        internal int[,,] GetCoord2BlockIDOfChunk(int x, int y, int z)
        {
            if (ChunkCoordIsOutOfIslandRange(x, y, z))
            {
                throw new Exception($"Chunk coordinate:({x},{y},{z})is out of {GetType()} island range");
            }
            else
            {
                var worldChunkCoord = new Coord3Int(x, y, z);
                return GenerateCoord2BlockIDOfChunk(worldChunkCoord);
            }
        }

        protected abstract int[,,] GenerateCoord2BlockIDOfChunk(Coord3Int worldChunkCoord);
        private bool ChunkCoordIsOutOfIslandRange(int x, int y, int z)
        {
            var result = x < SouthwestChunkCoord.x || y < SouthwestChunkCoord.y || x > SouthwestChunkCoord.x + Length || y > SouthwestChunkCoord.y + Length || y < 0 || y > Constants.WorldHeight;
            return result;
        }
    }
}
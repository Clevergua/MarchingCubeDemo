using Core.Math;

namespace Terrain
{
    public class PrairieCampIsland : Island
    {
        private static readonly int length = 2;
        internal override int Length { get { return length; } }

        protected override int[,,] GenerateCoord2BlockIDOfChunk(Coord3Int worldChunkCoord)
        {
            var worldCenterBlockCoord = SouthwestChunkCoord * Constants.ChunkLength + LocalCenterCoord;
            var coord2BlockOfChunk = new int[Constants.ChunkLength, Constants.ChunkLength, Constants.ChunkLength];
            for (int blockX = 0; blockX < Constants.ChunkLength; blockX++)
            {
                for (int blockZ = 0; blockZ < Constants.ChunkLength; blockZ++)
                {
                    for (int blockY = 0; blockY < Constants.ChunkLength; blockY++)
                    {

                    }
                }
            }

            return coord2BlockOfChunk;
        }
    }
}
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
            for (int localBlockX = 0; localBlockX < Constants.ChunkLength; localBlockX++)
            {
                for (int localBlockZ = 0; localBlockZ < Constants.ChunkLength; localBlockZ++)
                {
                    for (int localBlockY = 0; localBlockY < Constants.ChunkLength; localBlockY++)
                    {
                        var worldBlockCoord = worldChunkCoord * Constants.ChunkLength + new Coord3Int(localBlockX, localBlockY, localBlockZ);
                        
                    }
                }
            }

            return coord2BlockOfChunk;
        }
    }
}
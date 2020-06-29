using Core.Math;
namespace Terrain
{
    public abstract class Island
    {
        internal Coord2Int CenterCoord
        {
            get
            {
                var v = Constants.ChunkLength * Length / 2;
                return new Coord2Int(v, v);
            }
        }
        internal Coord2Int SouthwestChunkCoord { get; set; }
        internal abstract int Length { get; }
        internal abstract int[,,] GetCoord2BlockIDOfChunk(int x, int y, int z, int chunkLength);
    }
}
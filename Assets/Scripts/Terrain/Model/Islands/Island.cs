using Math;

public abstract class Island
{
    public Island(int chunkLength)
    {
        this.chunkLength = chunkLength;
    }
    private int chunkLength;
    internal Coord2Int CenterCoord
    {
        get
        {
            var v = chunkLength * Length / 2;
            return new Coord2Int(v, v);
        }
    }
    internal Coord2Int SouthwestChunkCoord { get; set; }
    internal abstract int Length { get; }
    internal abstract int[,,] GetCoord2BlockIDOfChunk(int x, int y, int z, int chunkLength);
}


public class TemperatureStartingIsland : Island
{
    internal override int Length { get { return 2; } }
    internal override int[,,] GetCoord2BlockIDOfChunk(int x, int y, int z, int chunkLength)
    {
        var coord2BlockOfChunk = new int[chunkLength, chunkLength, chunkLength];


        return coord2BlockOfChunk;
    }
}

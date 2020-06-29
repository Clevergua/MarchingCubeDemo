using System;

public class LandVM
{
    private Layer land;
    private int length;
    private int height;
    private int chunkLength;

    public LandVM(Layer land, int length, int height, int chunkLength)
    {
        this.land = land ?? throw new ArgumentNullException(nameof(land));
        this.length = length;
        this.height = height;
        this.chunkLength = chunkLength;
    }

    public int Length { get { return length; } }
    public int Height { get { return height; } }
    public int ChunkLength { get { return chunkLength; } }

    internal int GetBlockID(int x, int y, int z)
    {
        return land.GetBlockID(x, y, z);
    }

    internal bool ContainsCoord(int x, int y, int z)
    {
        var legalX = x >= 0 && x < land.GetLength(0);
        var legalY = y >= 0 && y < land.GetLength(1);
        var legalZ = z >= 0 && z < land.GetLength(2);
        return legalX && legalY && legalZ;
    }
}

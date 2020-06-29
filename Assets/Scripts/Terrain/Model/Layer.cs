using System;
using System.Collections.Generic;

public class Layer
{
    private int[,,] coord2BlockID;
    private IReadOnlyList<Island> islands;

    public Layer(int[,,] coord2BlockID, IReadOnlyList<Island> islands)
    {
        this.coord2BlockID = coord2BlockID;
        this.islands = islands;
    }

    internal int GetBlockID(int x, int y, int z)
    {
        return coord2BlockID[x, y, z];
    }
    internal int GetLength(int i)
    {
        return coord2BlockID.GetLength(i);
    }
}
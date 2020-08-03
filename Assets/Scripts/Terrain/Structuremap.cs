using System;
using System.Collections.Generic;

namespace Terrain
{
    internal class Structuremap
    {
        public int[,] coord2ID;
        public List<Structure> id2Structure;

        public Structuremap(int xLength, int zLength)
        {
            coord2ID = new int[xLength, zLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    coord2ID[x, z] = -1;
                }
            }
            id2Structure = new List<Structure>();
        }
    }
}
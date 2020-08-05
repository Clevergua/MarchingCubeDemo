using System.Collections.Generic;

namespace Terrain
{
    internal class Pathmap
    {
        private List<Path> id2Path;
        private int[,] coord2ID;

        public Pathmap(int xLength, int zLength)
        {
            id2Path = new List<Path>();
            int[,] coord2ID = new int[xLength, zLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int z = 0; z < zLength; z++)
                {
                    coord2ID[x, z] = -1;
                }
            }
        }
    }
}
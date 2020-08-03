using System;
using System.Collections.Generic;

namespace Terrain
{
    internal class Territorymap
    {
        public int[,] coord2ID;
        public List<Territory> id2Territory;

        public Territorymap(int xLength, int zLength)
        {
            coord2ID = new int[xLength, zLength];
            id2Territory = new List<Territory>();
            Reset();
        }

        internal void Reset()
        {
            id2Territory?.Clear();
            for (int x = 0; x < coord2ID.GetLength(0); x++)
            {
                for (int z = 0; z < coord2ID.GetLength(1); z++)
                {
                    coord2ID[x, z] = -1;
                }
            }
        }
    }
}
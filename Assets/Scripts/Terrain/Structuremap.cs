using System;
using System.Collections.Generic;

namespace Terrain
{
    internal class Structuremap
    {
        public int[,] coord2ID;
        public IReadOnlyList<Structure> id2Structure;

        public Structuremap(int[,] coord2ID, IReadOnlyList<Structure> id2Structure)
        {
            this.coord2ID = coord2ID ?? throw new ArgumentNullException();
            this.id2Structure = id2Structure ?? throw new ArgumentNullException();
        }
    }
}
using System;
using System.Collections.Generic;

namespace Terrain
{
    internal class Structuremap
    {
        public int[,] localStructuredatamap;
        public IReadOnlyList<Structure> localID2Structure;

        public Structuremap(int[,] localStructuredatamap, IReadOnlyList<Structure> localID2Structure)
        {
            this.localStructuredatamap = localStructuredatamap ?? throw new ArgumentNullException();
            this.localID2Structure = localID2Structure ?? throw new ArgumentNullException();
        }
    }
}
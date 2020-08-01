using Core;
using System.Collections.Generic;

namespace Terrain
{
    /// <summary>
    /// 领地
    /// </summary>
    internal abstract class Territory
    {
        protected int[,] structuremap;
        protected List<Structure> id2Structure;
        public Territory()
        {
            id2Structure = new List<Structure>();
            var length = Range * 2 + 1;
            structuremap = new int[length, length];
            for (int x = 0; x < structuremap.GetLength(0); x++)
            {
                for (int z = 0; z < structuremap.GetLength(1); z++)
                {
                    structuremap[x, z] = -1;
                }
            }
        }
        public abstract int Range { get; }
        public abstract IEnumerator<Structuremap> GenerateStructuremap();
        public Coord2Int WorldCoord { get; internal set; }

    }
}
using System.Collections.Generic;

namespace Terrain
{
    public class Layer
    {
        public int[,,] blockmap;
        private int[,] temperaturemap;
        private int[,] humiditymap;
        private int[,] structuremap;

        private IReadOnlyList<Island> islands;

        public Layer(int[,,] blockmap, IReadOnlyList<Island> islands)
        {
            this.blockmap = blockmap;
            this.islands = islands;
        }

        internal int GetBlockID(int x, int y, int z)
        {
            return blockmap[x, y, z];
        }
        internal int GetLength(int i)
        {
            return blockmap.GetLength(i);
        }
    }
}

using System.Collections.Generic;

namespace Terrain
{
    public class Layer
    {
        public byte[,,] blockmap;
        private int[,] temperaturemap;
        private int[,] humiditymap;
        private int[,] structuremap;

        public Layer(byte[,,] blockmap)
        {
            this.blockmap = blockmap;
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

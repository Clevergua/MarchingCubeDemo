using System.Collections.Generic;

namespace Terrain
{
    internal class Pathmap
    {
        private int length;
        private int width;
        private PathBlock[,] coord2PathBlock;

        public int Length { get { return length; } }
        public int Width { get { return width; } }
        public PathBlock this[int x, int z]
        {
            get
            {
                return coord2PathBlock[x, z];
            }
        }

        public Pathmap(int length, int width)
        {
            this.length = length;
            this.width = width;
            coord2PathBlock = new PathBlock[length, width];
        }
    }
}
using Core;
using System.Collections.Generic;

namespace Terrain
{
    public class Pathmap
    {
        public static readonly int PathRange = 4;

        private int length;
        private int width;
        private bool[,] map;
        public int Length { get { return length; } }
        public int Width { get { return width; } }
        public bool this[int x, int z]
        {
            internal set
            {
                map[x, z] = value;
            }
            get
            {
                return map[x, z];
            }
        }

        public Pathmap(int length, int width)
        {
            this.length = length;
            this.width = width;
            map = new bool[length, width];
        }
    }
}
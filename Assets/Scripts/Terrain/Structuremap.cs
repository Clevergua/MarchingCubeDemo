using Core;
using System;
using System.Collections.Generic;

namespace Terrain
{
    internal class Structuremap
    {
        private int length;
        private int width;
        private int[,] coord2ID;
        private List<Structure> id2Structure;
        private Dictionary<Structure, Coord2Int> structure2Coord;

        public int Length
        {
            get
            {
                return length;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
        }
        public int this[int x, int z]
        {
            get
            {
                return coord2ID[x, z];
            }
        }
        public IReadOnlyList<Structure> ID2Structure
        {
            get
            {
                return id2Structure;
            }
        }
        public IReadOnlyDictionary<Structure, Coord2Int> Structure2Coord
        {
            get
            {
                return structure2Coord;
            }
        }
        public Structuremap(int length, int width)
        {
            this.length = length;
            this.width = width;
            structure2Coord = new Dictionary<Structure, Coord2Int>();
            coord2ID = new int[length, width];
            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < width; z++)
                {
                    coord2ID[x, z] = -1;
                }
            }
            id2Structure = new List<Structure>();
        }
    }
}
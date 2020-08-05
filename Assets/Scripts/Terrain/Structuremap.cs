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
        private Dictionary<Structure, Coord2Int> structure2SWCoord;

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

        internal bool TryAddStructure(Structure structure, Coord2Int swCoord)
        {
            if (InRange(swCoord.x, swCoord.y) && InRange(swCoord.x + structure.Length, swCoord.y + structure.Width))
            {
                for (int x = 0; x < structure.Length; x++)
                {
                    for (int z = 0; z < structure.Width; z++)
                    {
                        if (coord2ID[x, z] == -1)
                        {
                            //pass
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            for (int x = 0; x < structure.Length; x++)
            {
                for (int z = 0; z < structure.Width; z++)
                {
                    coord2ID[swCoord.x + x, swCoord.y + z] = id2Structure.Count;
                }
            }
            id2Structure.Add(structure);
            structure2SWCoord.Add(structure, swCoord);
            return true;
        }

        private bool InRange(int x, int z)
        {
            return x <= Length && z < Width && x >= 0 && z >= 0;
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
                return structure2SWCoord;
            }
        }
        public Structuremap(int length, int width)
        {
            this.length = length;
            this.width = width;
            structure2SWCoord = new Dictionary<Structure, Coord2Int>();
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
using Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Terrain
{
    internal class Territorymap
    {
        private int length;
        private int width;
        private int[,] coord2ID;
        private List<Territory> id2Territory;
        private Dictionary<Territory, Coord2Int> territory2Coord;

        public int Length
        {
            get { return length; }
        }
        public int Width
        {
            get { return width; }
        }
        public int this[int x, int z]
        {
            get
            {
                return coord2ID[x, z];
            }
        }
        public IReadOnlyList<Territory> ID2Territory
        {
            get
            {
                return id2Territory;
            }
        }
        public IReadOnlyDictionary<Territory, Coord2Int> Territory2Coord
        {
            get
            {
                return territory2Coord;
            }
        }

        public Territorymap(int length, int width)
        {
            this.length = length;
            this.width = width;
            coord2ID = new int[length, width];
            id2Territory = new List<Territory>();
            territory2Coord = new Dictionary<Territory, Coord2Int>();
            Reset();
        }

        internal void Reset()
        {
            territory2Coord.Clear();
            id2Territory?.Clear();
            for (int x = 0; x < coord2ID.GetLength(0); x++)
            {
                for (int z = 0; z < coord2ID.GetLength(1); z++)
                {
                    coord2ID[x, z] = -1;
                }
            }
        }

        internal bool TryAddTerritory(Coord2Int centerCoord, Territory territory)
        {
            if (InRange(centerCoord.x - territory.Range, centerCoord.y - territory.Range) && InRange(centerCoord.x + territory.Range, centerCoord.y + territory.Range))
            {
                for (int x = centerCoord.x - territory.Range; x < centerCoord.x + territory.Range; x++)
                {
                    for (int y = centerCoord.y - territory.Range; y < centerCoord.y + territory.Range; y++)
                    {
                        if (coord2ID[x, y] == -1)
                        {
                            //Do nothing
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
            
            var index = id2Territory.Count;
            id2Territory.Add(territory);
            territory2Coord.Add(territory, centerCoord);
            for (int x = centerCoord.x - territory.Range; x < centerCoord.x + territory.Range; x++)
            {
                for (int y = centerCoord.y - territory.Range; y < centerCoord.y + territory.Range; y++)
                {
                    coord2ID[x, y] = index;
                }
            }
            return true;
        }

        private bool InRange(int x, int y)
        {
            return !(x < 0 || y < 0 || x >= coord2ID.GetLength(0) || y >= coord2ID.GetLength(1));
        }
    }
}
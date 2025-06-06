﻿using Core;
using System;
using System.Collections.Generic;

namespace Terrain
{
    /// <summary>
    /// 建筑图
    /// 用于每一个领地存储自己的建筑信息
    /// </summary>
    internal class Structuremap
    {
        private int length;
        private int width;
        private int[,] coord2ID;
        private List<Structure> id2Structure;

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
                        if (coord2ID[swCoord.x + x, swCoord.y + z] == -1)
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
            structure.TerritorySWCoord = swCoord;
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
        public Structuremap(int length, int width)
        {
            this.length = length;
            this.width = width;
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
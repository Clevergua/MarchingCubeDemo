using Core;
using UnityEngine;

namespace Terrain
{
    /// <summary>
    /// 建筑
    /// </summary>
    internal abstract class Structure
    {
        protected byte[,,] coord2Block;
        protected Direction direction;

        /// <summary>
        /// 建筑数据
        /// </summary>
        public byte[,,] Coord2Block
        {
            get
            {
                return coord2Block;
            }
        }
        /// <summary>
        /// 建筑的朝向,默认为南.
        /// </summary>
        public Direction Direction
        {
            get
            {
                return direction;
            }
            set
            {
                RotateData(value);
                direction = value;
            }
        }
        /// <summary>
        /// x,z轴的中心点坐标
        /// </summary>
        public Coord2Int Pivot2Int
        {
            get
            {
                return new Coord2Int(coord2Block.GetLength(0) / 2, coord2Block.GetLength(2) / 2);
            }
        }
        /// <summary>
        /// x,y,z轴的中心点坐标
        /// </summary>
        public Coord3Int Pivot3Int
        {
            get
            {
                return new Coord3Int(coord2Block.GetLength(0) / 2, coord2Block.GetLength(1) / 2, coord2Block.GetLength(2) / 2);
            }
        }

        private void RotateData(Direction direction)
        {
            switch (Mathf.Abs((int)direction - (int)this.direction))
            {
                case 0:
                    {
                        //Do nothing..
                        break;
                    }
                case 1:
                    {
                        var newData = new byte[coord2Block.GetLength(2), coord2Block.GetLength(1), coord2Block.GetLength(0)];
                        for (int x = 0; x < coord2Block.GetLength(0); x++)
                        {
                            for (int z = 0; z < coord2Block.GetLength(2); z++)
                            {
                                for (int y = 0; y < coord2Block.GetLength(1); y++)
                                {
                                    newData[z, y, coord2Block.GetLength(0) - 1 - x] = coord2Block[x, y, z];
                                }
                            }
                        }
                        coord2Block = newData;
                    }
                    break;
                case 2:
                    {
                        var newData = new byte[coord2Block.GetLength(0), coord2Block.GetLength(1), coord2Block.GetLength(2)];
                        for (int x = 0; x < coord2Block.GetLength(0); x++)
                        {
                            for (int z = 0; z < coord2Block.GetLength(2); z++)
                            {
                                for (int y = 0; y < coord2Block.GetLength(1); y++)
                                {
                                    newData[coord2Block.GetLength(0) - 1 - x, y, coord2Block.GetLength(2) - 1 - z] = coord2Block[x, y, z];
                                }
                            }
                        }
                        coord2Block = newData;
                    }
                    break;
                case 3:
                    {
                        var newData = new byte[coord2Block.GetLength(2), coord2Block.GetLength(1), coord2Block.GetLength(0)];
                        for (int x = 0; x < coord2Block.GetLength(0); x++)
                        {
                            for (int z = 0; z < coord2Block.GetLength(2); z++)
                            {
                                for (int y = 0; y < coord2Block.GetLength(1); y++)
                                {
                                    newData[coord2Block.GetLength(2) - 1 - z, y, x] = coord2Block[x, y, z];
                                }
                            }
                        }
                        coord2Block = newData;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
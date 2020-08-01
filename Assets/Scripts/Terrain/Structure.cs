using Core;
using UnityEngine;

namespace Terrain
{
    /// <summary>
    /// 建筑
    /// </summary>
    internal abstract class Structure
    {
        protected byte[,,] data;
        protected Direction direction;

        /// <summary>
        /// 建筑数据
        /// </summary>
        public byte[,,] Data
        {
            get
            {
                return data;
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
                return new Coord2Int(data.GetLength(0) / 2, data.GetLength(2) / 2);
            }
        }
        /// <summary>
        /// x,y,z轴的中心点坐标
        /// </summary>
        public Coord3Int Pivot3Int
        {
            get
            {
                return new Coord3Int(data.GetLength(0) / 2, data.GetLength(1) / 2, data.GetLength(2) / 2);
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
                        var newData = new byte[data.GetLength(2), data.GetLength(1), data.GetLength(0)];
                        for (int x = 0; x < data.GetLength(0); x++)
                        {
                            for (int z = 0; z < data.GetLength(2); z++)
                            {
                                for (int y = 0; y < data.GetLength(1); y++)
                                {
                                    newData[z, y, data.GetLength(0) - 1 - x] = data[x, y, z];
                                }
                            }
                        }
                        data = newData;
                    }
                    break;
                case 2:
                    {
                        var newData = new byte[data.GetLength(0), data.GetLength(1), data.GetLength(2)];
                        for (int x = 0; x < data.GetLength(0); x++)
                        {
                            for (int z = 0; z < data.GetLength(2); z++)
                            {
                                for (int y = 0; y < data.GetLength(1); y++)
                                {
                                    newData[data.GetLength(0) - 1 - x, y, data.GetLength(2) - 1 - z] = data[x, y, z];
                                }
                            }
                        }
                        data = newData;
                    }
                    break;
                case 3:
                    {
                        var newData = new byte[data.GetLength(2), data.GetLength(1), data.GetLength(0)];
                        for (int x = 0; x < data.GetLength(0); x++)
                        {
                            for (int z = 0; z < data.GetLength(2); z++)
                            {
                                for (int y = 0; y < data.GetLength(1); y++)
                                {
                                    newData[data.GetLength(2) - 1 - z, y, x] = data[x, y, z];
                                }
                            }
                        }
                        data = newData;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
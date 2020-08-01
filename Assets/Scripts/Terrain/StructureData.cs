using Core;
using UnityEngine;

namespace Terrain
{
    internal class StructureData
    {
        private byte[,,] blockmap;
        private Coord3Int xzCenter;
        public Direction direction = Direction.South;

        public StructureData(byte[,,] blockmap)
        {
            SetBlockmap(blockmap);
        }

        /// <summary>
        /// 块数据图
        /// </summary>
        public byte[,,] Blockmap { get => blockmap; }
        /// <summary>
        /// 底部中心位置
        /// </summary>
        public Coord3Int XZCenter { get => xzCenter; }

        internal void SetBlockmap(byte[,,] blockmap)
        {
            this.blockmap = blockmap;
            xzCenter = new Coord3Int(blockmap.GetLength(0) / 2, 0, blockmap.GetLength(2) / 2);
        }
        internal void RotateSturctureData(Direction direction)
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
                        var newMap = new byte[Blockmap.GetLength(2), Blockmap.GetLength(1), Blockmap.GetLength(0)];
                        for (int x = 0; x < Blockmap.GetLength(0); x++)
                        {
                            for (int z = 0; z < Blockmap.GetLength(2); z++)
                            {
                                for (int y = 0; y < Blockmap.GetLength(1); y++)
                                {
                                    newMap[z, y, Blockmap.GetLength(0) - 1 - x] = Blockmap[x, y, z];
                                }
                            }
                        }
                        SetBlockmap(newMap);
                    }
                    break;
                case 2:
                    {
                        var newMap = new byte[Blockmap.GetLength(0), Blockmap.GetLength(1), Blockmap.GetLength(2)];
                        for (int x = 0; x < Blockmap.GetLength(0); x++)
                        {
                            for (int z = 0; z < Blockmap.GetLength(2); z++)
                            {
                                for (int y = 0; y < Blockmap.GetLength(1); y++)
                                {
                                    newMap[Blockmap.GetLength(0) - 1 - x, y, Blockmap.GetLength(2) - 1 - z] = Blockmap[x, y, z];
                                }
                            }
                        }
                        SetBlockmap(newMap);
                    }
                    break;
                case 3:
                    {
                        var newMap = new byte[Blockmap.GetLength(2), Blockmap.GetLength(1), Blockmap.GetLength(0)];
                        for (int x = 0; x < Blockmap.GetLength(0); x++)
                        {
                            for (int z = 0; z < Blockmap.GetLength(2); z++)
                            {
                                for (int y = 0; y < Blockmap.GetLength(1); y++)
                                {
                                    newMap[Blockmap.GetLength(2) - 1 - z, y, x] = Blockmap[x, y, z];
                                }
                            }
                        }
                        SetBlockmap(newMap);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
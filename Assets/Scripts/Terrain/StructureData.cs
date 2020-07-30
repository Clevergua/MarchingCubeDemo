using Core;

namespace Terrain
{
    internal class StructureData
    {
        private byte[,,] blockmap;
        private Coord3Int bottomCenterCoord;

        public StructureData(byte[,,] blockmap)
        {
            this.blockmap = blockmap;
            bottomCenterCoord = new Coord3Int(blockmap.GetLength(0) / 2, 0, blockmap.GetLength(2) / 2);
        }

        /// <summary>
        /// 块数据图
        /// </summary>
        public byte[,,] Blockmap { get => blockmap; }
        /// <summary>
        /// 底部中心位置
        /// </summary>
        public Coord3Int BottomCenterCoord { get => bottomCenterCoord; }
    }
}
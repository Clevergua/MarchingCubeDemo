using Core;

namespace Terrain
{
    internal class StructureData
    {
        private byte[,,] coord2Block;
        private Coord3Int localPivot;

        public StructureData(byte[,,] coord2Block, Coord3Int localPivot)
        {
            this.coord2Block = coord2Block;
            this.localPivot = localPivot;
        }

        public byte[,,] Coord2Block { get; }
        public Coord3Int LocalPivot { get; }
    }
}
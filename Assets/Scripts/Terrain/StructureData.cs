using Core;

namespace Terrain
{
    internal class StructureData
    {
        public StructureData(byte[,,] coord2Block, Coord3Int startPoint)
        {
            Coord2Block = coord2Block;
            StartPoint = startPoint;
        }

        public byte[,,] Coord2Block { get; }
        public Coord3Int StartPoint { get; }
    }
}
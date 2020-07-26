using Core;

namespace Terrain
{
    internal abstract class Structure
    {
        internal abstract StructureData GetStructureData(byte[,,] blockmap, Coord3Int centerPoint, int seed);
    }
}
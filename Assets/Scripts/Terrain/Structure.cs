using Core;

namespace Terrain
{
    internal abstract class Structure
    {
        internal abstract StructureData GetStructureData(byte[,,] blockmap, Coord3Int pivot, int seed);
    }
}
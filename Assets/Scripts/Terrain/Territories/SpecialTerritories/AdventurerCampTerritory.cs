using Core;

namespace Terrain
{
    internal class AdventurerCampTerritory : SpecialTerritory
    {
        public override int Range { get { return 16; } }

        internal override void ArrangeStructures(int seed, StructureFactory structureFactory)
        {
            var tent = structureFactory.GetStructure<Tent>();
            //var carbonCoord = new Coord3Int(CenterCoord.x, heightmap[CenterCoord.x, CenterCoord.y] + 1, CenterCoord.y);
            //blockmap[carbonCoord.x, carbonCoord.y, carbonCoord.z] = (byte)BlockType.Carbon;
            var tentData = tent.GetRandomColorTent(CenterCoord, seed);
        }
    }
}
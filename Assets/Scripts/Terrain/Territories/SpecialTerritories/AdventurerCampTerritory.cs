using Core;
using System.Collections;
using System.Collections.Generic;

namespace Terrain
{
    internal class AdventurerCampTerritory : SpecialTerritory
    {
        private int seed;
        public AdventurerCampTerritory(int seed)
        {
            this.seed = seed;

        }
        public override int Range { get { return 16; } }

        public override IEnumerator<Structuremap> GenerateStructuremap()
        {
            var worldCenter = new Coord3Int(WorldCoord.x, heightmap[WorldCoord.x, WorldCoord.y], WorldCoord.y);
            var tent = structureFactory.GetStructure<Tent>();
            var bonfire = structureFactory.GetStructure<Bonfire>();

            var tentData = tent.GetData(worldCenter, seed);
            var bonfireData = bonfire.GetData();

            for (int x = 0; x < bonfireData.Blockmap.GetLength(0); x++)
            {
                for (int z = 0; z < bonfireData.Blockmap.GetLength(2); z++)
                {
                    localStructuredatamap[Range - tentData.XZCenter.x, Range - tentData.XZCenter.y] = localID2StructureData.Count;
                }
            }
            localID2StructureData.Add(bonfireData);

            yield return null;
        }

    }
}
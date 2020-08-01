using Core;
using System.Collections;
using System.Collections.Generic;

namespace Terrain
{
    internal class AdventurerCampTerritory : SpecialTerritory
    {
        public override int Range { get { return 16; } }

        internal override IEnumerator FillLocalStructuredatamap(int[,] localStructuredatamap, List<StructureData> localID2StructureData, int seed, StructureFactory structureFactory, int[,] heightmap, int[,] temperaturemap, int[,] humiditymap, BiomeSelector biomeSelector)
        {
            //重置localStructuredatamap
            for (int x = 0; x < localStructuredatamap.GetLength(0); x++)
            {
                for (int z = 0; z < localStructuredatamap.GetLength(1); z++)
                {
                    localStructuredatamap[x, z] = -1;
                }
            }

            var worldCenter = new Coord3Int(CenterCoord.x, heightmap[CenterCoord.x, CenterCoord.y], CenterCoord.y);
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
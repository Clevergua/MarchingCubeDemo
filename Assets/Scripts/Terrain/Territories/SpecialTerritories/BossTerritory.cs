using System.Collections;
using System.Collections.Generic;

namespace Terrain
{
    internal class BossTerritory : SpecialTerritory
    {
        public override int Range { get { return 32; } }

        internal override IEnumerator FillLocalStructuredatamap(int[,] localStructuredatamap, List<StructureData> localID2StructureData, int seed, StructureFactory structureFactory, int[,] heightmap, int[,] temperaturemap, int[,] humiditymap, BiomeSelector biomeSelector)
        {
            throw new System.NotImplementedException();
        }
    }
}
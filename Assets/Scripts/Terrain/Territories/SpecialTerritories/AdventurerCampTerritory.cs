namespace Terrain
{
    internal class AdventurerCampTerritory : SpecialTerritory
    {
        public override int Range { get { return 16; } }
        internal override void GenerateStructures(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, StructureFactory structureFactory, int seed)
        {
            var tent = structureFactory.GetStructure<Tent>();
            tent.GetStructureData(blockmap, , seed);

        }
    }
}
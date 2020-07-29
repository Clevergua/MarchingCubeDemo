namespace Terrain
{
    internal class BossTerritory : SpecialTerritory
    {
        public override int Range { get { return 32; } }

        internal override void GenerateStructures(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, StructureFactory structureFactory, int seed)
        {
        }
    }
}
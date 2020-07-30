namespace Terrain
{
    internal class CityTerritory : NormalTerritory
    {
        public override int Range { get { return 32; } }

        internal override void ArrangeStructures(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, StructureFactory structureFactory, int seed)
        {
        }
    }
}
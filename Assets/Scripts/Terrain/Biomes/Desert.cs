

using Core;
using System.Collections.Generic;

namespace Terrain
{
    internal class Desert : Biome
    {
        public Desert(StructureFactory structureFactory) : base(structureFactory) { }

        internal override void Growing(byte[,,] blockmap, int x, int z, int seed)
        {
            throw new System.NotImplementedException();
        }

        internal override void Planting(byte[,,] blockmap, int x, int z, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, int[,] territorymap, IReadOnlyList<Territory> id2Territory, IReadOnlyDictionary<Coord3Int, int> coord2MinDistanceFromPath, int seed)
        {
            throw new System.NotImplementedException();
        }

        internal override void ProcessPitCoords(IReadOnlyList<Coord3Int> pitCoordsGroup, byte[,,] blockmap, int[,] heightmap, int seed)
        {
            throw new System.NotImplementedException();
        }
    }
}

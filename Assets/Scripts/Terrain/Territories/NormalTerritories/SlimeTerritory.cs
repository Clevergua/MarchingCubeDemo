using UnityEngine;
using System.Collections;
namespace Terrain
{
    internal class SlimeTerritory : NormalTerritory
    {
        public override int Range { get { return 32; } }

        internal override void GenerateStructures(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, StructureFactory structureFactory, int seed)
        {
        }
    }
}
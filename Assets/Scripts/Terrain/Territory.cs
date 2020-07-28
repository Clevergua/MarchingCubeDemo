using Core;
using System;

namespace Terrain
{
    internal abstract class Territory
    {
        public abstract int Range { get; }
        public Coord2Int CenterCoord { get; internal set; }
        internal abstract void GenerateStructures(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, StructureFactory structureFactory, int seed);
    }
}
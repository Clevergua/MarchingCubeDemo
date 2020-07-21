using Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    public abstract class Biome
    {
        internal abstract void ProcessPitCoords(IReadOnlyList<Coord3Int> pitCoordsGroup, byte[,,] blockmap, int[,] heightmap, int seed);

        internal abstract IEnumerator Growing(byte[,,] blockmap, int x, int z, int seed);
    }
}


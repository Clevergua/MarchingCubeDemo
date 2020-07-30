using Core;
using System;
using System.Collections.Generic;

namespace Terrain
{
    internal abstract class Territory
    {
        public abstract int Range { get; }
        public Coord2Int CenterCoord { get; internal set; }
        internal abstract void ArrangeStructures(int seed, StructureFactory structureFactory);
    }
}
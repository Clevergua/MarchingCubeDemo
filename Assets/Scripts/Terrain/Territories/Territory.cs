using Core;

namespace Terrain
{
    internal abstract class Territory
    {
        public abstract int Range { get; }
        public Coord2Int CenterCoord { get; internal set; }
    }
}
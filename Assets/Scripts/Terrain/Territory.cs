using Core;
using System.Collections.Generic;

namespace Terrain
{
    /// <summary>
    /// 领地
    /// </summary>
    internal abstract class Territory
    {
        public abstract int Range
        {
            get;
        }
        public int Length
        {
            get
            {
                return Range * 2 + 1;
            }
        }
        public Coord2Int WorldCoord
        {
            get;
            internal set;
        }
        public Coord2Int Pivot2Int
        {
            get
            {
                return new Coord2Int(Range, Range);
            }
        }
        public abstract IEnumerator<Structuremap> GenerateStructuremap(Environmentmap environmentmap, int seed);
    }
}
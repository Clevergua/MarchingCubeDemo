using Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Terrain
{
    /// <summary>
    /// 领地
    /// </summary>
    internal abstract class Territory
    {
        public Structuremap structuremap { get; protected set; }
        public abstract int Range { get; }
        public int Length
        {
            get
            {
                return Range * 2 + 1;
            }
        }
        public Coord2Int Pivot2Int
        {
            get
            {
                return new Coord2Int(Range, Range);
            }
        }

        /// <summary>
        /// 根据环境信息和种子生成建筑图
        /// </summary>
        /// <param name="environmentmap"></param>
        /// <param name="seed"></param>
        public abstract void GenerateStructuremap(Environmentmap environmentmap, int seed);
        /// <summary>
        /// 生成局部的道路图
        /// </summary>
        internal virtual bool[,] GeneratePathmap()
        {
            var pathmap = new bool[structuremap.Length, structuremap.Width];
            for (int x = 0; x < pathmap.GetLength(0); x++)
            {
                for (int z = 0; z < pathmap.GetLength(1); z++)
                {
                }
            }
        }
    }
}
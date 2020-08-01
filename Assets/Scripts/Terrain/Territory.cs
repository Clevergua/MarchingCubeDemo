using Core;
using System.Collections;
using System.Collections.Generic;

namespace Terrain
{
    internal abstract class Territory
    {
        public abstract int Range { get; }
        public Coord2Int CenterCoord { get; internal set; }

        /// <summary>
        /// 填充localStructuredatamap,与localID2StructureData的方法
        /// </summary>
        /// <param name="localStructuredatamap">长度Range*2+1的二维数组</param>
        /// <param name="localID2StructureData">需要在方法中填充的空列表</param>
        /// <param name="seed"></param>
        /// <param name="structureFactory"></param>
        /// <param name="heightmap"></param>
        /// <param name="temperaturemap"></param>
        /// <param name="humiditymap"></param>
        /// <param name="biomeSelector"></param>
        /// <returns></returns>
        internal abstract IEnumerator FillLocalStructuredatamap(int[,] localStructuredatamap, List<StructureData> localID2StructureData, int seed, StructureFactory structureFactory, int[,] heightmap, int[,] temperaturemap, int[,] humiditymap, BiomeSelector biomeSelector);
    }
}
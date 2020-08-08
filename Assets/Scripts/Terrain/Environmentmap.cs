using Core;
using System.Collections.Generic;
using System;
namespace Terrain
{
    /// <summary>
    /// 温度湿度基本海拔以及生物群落的二维环境图
    /// </summary>
    internal class Environmentmap
    {
        private int[,] baseheightmap;
        private int[,] basetemperaturemap;
        private int[,] basehumiditymap;
        private IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome;

        public Environmentmap(int[,] baseheightmap, int[,] basetemperaturemap, int[,] basehumiditymap, IReadOnlyDictionary<EnvironmentDegree, Biome> environmentDegree2Biome)
        {
            //高度图
            this.baseheightmap = baseheightmap ?? throw new ArgumentNullException();
            //温度图
            this.basetemperaturemap = basetemperaturemap ?? throw new ArgumentNullException();
            //湿度图
            this.basehumiditymap = basehumiditymap ?? throw new ArgumentNullException();
            //群落配置
            this.environmentDegree2Biome = environmentDegree2Biome ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// 获得实际温度
        /// 在最低的初始海拔以下返回温度图中温度
        /// 随着高度升高气温逐渐递减
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public int GetActualTemperature(Coord3Int coord)
        {
            return GetActualTemperature(basetemperaturemap[coord.x, coord.z], coord.y);
        }
        /// <summary>
        /// 获得实际温度
        /// 在最低的初始海拔以下返回温度图中温度
        /// 随着高度升高气温逐渐递减
        /// </summary>
        /// <param name="baseTemperature"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public int GetActualTemperature(int baseTemperature, int height)
        {
            if (height < Constants.MinHeight)
            {
                return baseTemperature;
            }
            else
            {
                var dropedPerMeter = 0.1f;
                var temperature = baseTemperature - (int)((height - Constants.MinHeight) * dropedPerMeter);
                temperature = temperature < 0 ? 0 : temperature;
                return temperature;
            }
        }
        /// <summary>
        /// 根据温度湿度获取当前生物群落
        /// </summary>
        /// <param name="baseTemperature"></param>
        /// <param name="baseHumidity"></param>
        /// <returns></returns>
        public Biome GetBiome(int baseTemperature, int baseHumidity)
        {
            if (baseTemperature < 33)
            {
                if (baseHumidity < 33)
                {
                    return environmentDegree2Biome[EnvironmentDegree.LowTemperatureLowHumidity];
                }
                else if (baseHumidity < 66)
                {
                    return environmentDegree2Biome[EnvironmentDegree.LowTemperatureMediumHumidity];
                }
                else
                {
                    return environmentDegree2Biome[EnvironmentDegree.LowTemperatureHighHumidity];
                }
            }
            else if (baseTemperature < 66)
            {
                if (baseHumidity < 33)
                {
                    return environmentDegree2Biome[EnvironmentDegree.MediumTemperatureLowHumidity];
                }
                else if (baseHumidity < 66)
                {
                    return environmentDegree2Biome[EnvironmentDegree.MediumTemperatureLowHumidity];
                }
                else
                {
                    return environmentDegree2Biome[EnvironmentDegree.MediumTemperatureLowHumidity];
                }
            }
            else
            {
                if (baseHumidity < 33)
                {
                    return environmentDegree2Biome[EnvironmentDegree.HighTemperatureLowHumidity];
                }
                else if (baseHumidity < 66)
                {
                    return environmentDegree2Biome[EnvironmentDegree.HighTemperatureLowHumidity];
                }
                else
                {
                    return environmentDegree2Biome[EnvironmentDegree.HighTemperatureLowHumidity];
                }
            }

        }
        /// <summary>
        /// 根据当前x,z轴坐标获取当前生物群落
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public Biome GetBiome(Coord2Int coord)
        {
            return GetBiome(basetemperaturemap[coord.x, coord.y], basehumiditymap[coord.x, coord.y]);
        }
    }
}
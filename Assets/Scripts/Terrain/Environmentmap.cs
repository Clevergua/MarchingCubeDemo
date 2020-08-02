namespace Terrain
{
    internal class Environmentmap
    {
        public int xLength;
        public int zLength;
        public int[,] heightmap;
        public int[,] temperaturemap;
        public int[,] humiditymap;

        public Environmentmap(int xlength, int zLength)
        {
            this.xLength = xlength;
            this.zLength = zLength;
            //高度图
            heightmap = new int[xlength, zLength];
            //温度图
            temperaturemap = new int[xlength, zLength];
            //湿度图
            humiditymap = new int[xlength, zLength];
        }
    }
}
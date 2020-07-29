using Core;

namespace Terrain
{
    internal class AdventurerCampTerritory : SpecialTerritory
    {
        public override int Range { get { return 16; } }
        internal override void GenerateStructures(byte[,,] blockmap, BiomeSelector biomeSelector, int[,] temperaturemap, int[,] humiditymap, int[,] heightmap, StructureFactory structureFactory, int seed)
        {
            //var tent = structureFactory.GetStructure<Tent>();
            ////在中心生成篝火
            //var carbonCoord = new Coord3Int(CenterCoord.x, heightmap[CenterCoord.x, CenterCoord.y] + 1, CenterCoord.y);
            //blockmap[carbonCoord.x, carbonCoord.y, carbonCoord.z] = (byte)BlockType.Carbon;
            ////以中心为种子获取一个帐篷数据
            //var tentData = tent.GetStructureData(blockmap, carbonCoord, seed);
        }
    }
}
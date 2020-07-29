using Core;
using System;

namespace Terrain
{
    internal class Tent : DataDrivenStructure
    {
        private byte[,,] blackTent;
        public override void InitilazeData(byte[,,] data)
        {
            blackTent = data;
        }

        internal StructureData GetRandomColorTent(Coord3Int ranFactor, int seed)
        {
            var tent = new byte[blackTent.GetLength(0), blackTent.GetLength(1), blackTent.GetLength(2)];
            var fiberBlocks = new BlockType[]
            {
                BlockType.BlackFiber,
                BlockType.BlueFiber,
                BlockType.BrownFiber,
                BlockType.GrayFiber,
                BlockType.GreenFiber,
                BlockType.OrangeFiber,
                BlockType.RedFiber,
                BlockType.YellowFiber,
            };
            var index = RNG.Random3(ranFactor.x, ranFactor.y, ranFactor.z, seed + 2134) % fiberBlocks.Length;
            index = index > 0 ? index : -index;
            for (int x = 0; x < blackTent.GetLength(0); x++)
            {
                for (int y = 0; y < blackTent.GetLength(1); y++)
                {
                    for (int z = 0; z < blackTent.GetLength(2); z++)
                    {
                        tent[x, y, z] = blackTent[x, y, z];
                        if (tent[x, y, z] == (byte)BlockType.BlackFiber)
                        {
                            tent[x, y, z] = (byte)fiberBlocks[index];
                        }
                    }
                }
            }
            var localPivot = new Coord3Int(tent.GetLength(0) / 2, 0, tent.GetLength(2) / 2);
            return new StructureData(tent, localPivot);
        }
    }
}
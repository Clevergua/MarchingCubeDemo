using Core;
using System;

namespace Terrain
{
    internal class Tent : DataDrivenStructure
    {
        public Tent(Coord3Int ranFactor, int seed) : base()
        {
            RandomlyDyeTent(ranFactor, seed);
        }

        private void RandomlyDyeTent(Coord3Int ranFactor, int seed)
        {
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
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    for (int z = 0; z < data.GetLength(2); z++)
                    {
                        if (data[x, y, z] == (byte)BlockType.BlackFiber)
                        {
                            data[x, y, z] = (byte)fiberBlocks[index];
                        }
                    }
                }
            }
        }

    }
}
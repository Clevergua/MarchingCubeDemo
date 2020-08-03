using Core;
using System;

namespace Terrain
{
    internal class Tent : DataDrivenStructure
    {
        public Tent(int ranFactor, int seed) : base()
        {
            RandomlyDyeTent(ranFactor, seed);
        }

        private void RandomlyDyeTent(int ranFactor, int seed)
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
            var index = RNG.Random1(ranFactor, seed + 2134) % fiberBlocks.Length;
            index = index > 0 ? index : -index;
            for (int x = 0; x < coord2Block.GetLength(0); x++)
            {
                for (int y = 0; y < coord2Block.GetLength(1); y++)
                {
                    for (int z = 0; z < coord2Block.GetLength(2); z++)
                    {
                        if (coord2Block[x, y, z] == (byte)BlockType.BlackFiber)
                        {
                            coord2Block[x, y, z] = (byte)fiberBlocks[index];
                        }
                    }
                }
            }
        }

    }
}
﻿using Core;
using System;
using System.Collections.Generic;

namespace Terrain
{
    internal class Oak : Structure
    {
        public Oak(Coord3Int randomFactor, int seed)
        {
            coord2Block = GenerateOakData(randomFactor, seed);
        }

        private byte[,,] GenerateOakData(Coord3Int randomFactor, int seed)
        {
            var wood = (byte)BlockType.Wood;
            var data = new byte[8, 16, 8];
            //生成树跟
            var localPivot = new Coord3Int(data.GetLength(0) / 2, 0, data.GetLength(2) / 2);
            SetCoord2Block(data, localPivot, wood);
            for (int i = 0; i < 4; i++)
            {
                var dir = GetRandomHorizontalDirection(randomFactor.x, randomFactor.y, randomFactor.z, seed + i + 51);
                var c1 = localPivot + dir;
                SetCoord2Block(data, c1, wood);
            }
            //主干延申
            //2~6
            var trunkLength = RNG.Random3(randomFactor.x, randomFactor.y, randomFactor.z, seed - 85);
            trunkLength = trunkLength > 0 ? trunkLength : -trunkLength;
            trunkLength = trunkLength % 5 + 2;
            for (int u = 0; u < trunkLength; u++)
            {
                data[localPivot.x, u + 1, localPivot.z] = wood;
            }
            var rootTop = new Coord3Int(localPivot.x, trunkLength, localPivot.z);
            //生成树冠
            //0~2
            var canopyLength = RNG.Random3(rootTop.x + randomFactor.x, rootTop.y + randomFactor.y, rootTop.z + randomFactor.z, seed - 534) % 2 + 1;
            for (int u = 0; u < canopyLength; u++)
            {
                data[rootTop.x, rootTop.y + u + 1, rootTop.z] = wood;
            }
            SetLeaves(data, rootTop.x, rootTop.y + canopyLength, rootTop.z);
            //生成树枝与树叶
            //从树冠最上方开始选择
            var list = new List<Coord3Int>();
            list.Add(rootTop);
            for (int u = 0; u < canopyLength - 1; u++)
            {
                list.Add(rootTop + Coord3Int.up * (u + 1));
            }
            for (int t = 0; t < 24; t++)
            {
                var index = RNG.Random3(randomFactor.x, trunkLength + randomFactor.y, randomFactor.z, seed + t + 7);
                index = index > 0 ? index : -index;
                index = index % list.Count;

                var temp = list[index];
                list.RemoveAt(index);
                var outDirs = new List<Coord3Int>();
                if (temp.x < localPivot.x)
                {
                    outDirs.Add(Coord3Int.left);
                }
                else if (temp.x > localPivot.x)
                {
                    outDirs.Add(Coord3Int.right);
                }
                else
                {
                    outDirs.Add(Coord3Int.left);
                    outDirs.Add(Coord3Int.right);
                }
                if (temp.z < localPivot.z)
                {
                    outDirs.Add(Coord3Int.back);
                }
                else if (temp.z > localPivot.z)
                {
                    outDirs.Add(Coord3Int.forward);
                }
                else
                {
                    outDirs.Add(Coord3Int.back);
                    outDirs.Add(Coord3Int.forward);
                }
                var c = outDirs[t % outDirs.Count] + temp;
                if (c.x < 1 || c.x > 6 || c.z < 1 || c.z > 6)
                {
                    list.Insert(0, temp);
                }
                else
                {
                    SetLeaves(data, c.x, c.y, c.z);
                    data[c.x, c.y, c.z] = wood;
                    list.Add(temp);
                    list.Add(c);
                }
            }
            return data;
        }
        private void SetLeaves(byte[,,] coord2Block, int x, int y, int z)
        {
            SetLeaf(coord2Block, x + 1, y, z);
            SetLeaf(coord2Block, x - 1, y, z);
            SetLeaf(coord2Block, x, y + 1, z);
            SetLeaf(coord2Block, x, y, z + 1);
            SetLeaf(coord2Block, x, y, z - 1);
        }
        private void SetLeaf(byte[,,] coord2Block, int x, int y, int z)
        {
            if (coord2Block[x, y, z] == (byte)BlockType.Air)
            {
                coord2Block[x, y, z] = (byte)BlockType.Leaf;
            }
        }
        private void SetCoord2Block(byte[,,] blockmap, Coord3Int coord, byte blockType)
        {
            blockmap[coord.x, coord.y, coord.z] = blockType;
        }
        private Coord3Int GetRandomHorizontalDirection(int x, int y, int z, int seed)
        {
            var dirs = new Coord3Int[]
            {
                Coord3Int.left,
                Coord3Int.right,
                Coord3Int.back,
                Coord3Int.forward,
            };
            var r = RNG.Random3(x, y, z, seed);
            r = r > 0 ? r : -r;
            var index = r % 4;
            return dirs[index];
        }
    }
}
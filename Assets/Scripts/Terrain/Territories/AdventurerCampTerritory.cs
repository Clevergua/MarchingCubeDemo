using Core;
using System.Collections.Generic;

namespace Terrain
{
    internal class AdventurerCampTerritory : Territory
    {
        public override int Range { get { return 16; } }
        public override IEnumerator<Structuremap> GenerateStructuremap(Environmentmap environmentmap, int seed)
        {
            var structuremap = new Structuremap(Length, Length);

            //在中心创建一个篝火
            {
                var bonfire = new Bonfire();
                var swCoord = new Coord2Int(Pivot2Int.x - bonfire.Pivot2Int.x, Pivot2Int.y - bonfire.Pivot2Int.y);
                var index = structuremap.id2Structure.Count;
                for (int x = 0; x < bonfire.Coord2Block.GetLength(0); x++)
                {
                    for (int z = 0; z < bonfire.Coord2Block.GetLength(2); z++)
                    {
                        structuremap.coord2ID[swCoord.x + x, swCoord.y + z] = index;
                    }
                }
                structuremap.id2Structure.Add(bonfire);
            }

            //尝试创建4个帐篷
            {
                var factor = seed;
                for (int i = 0; i < 4; i++)
                {
                    var index = structuremap.id2Structure.Count;
                    var tent = new Tent(--factor, seed);

                    var tentLength = tent.Coord2Block.GetLength(0);
                    var tentWidth = tent.Coord2Block.GetLength(2);
                    var rx = RNG.Random1(--factor, seed) % (Length - tentLength);
                    var rz = RNG.Random1(--factor, seed) % (Length - tentWidth);
                    rx = rx > 0 ? rx : -rx;
                    rz = rz > 0 ? rz : -rz;
                    var ranSWCoord = new Coord2Int(rx, rz);
                    var canCreate = true;
                    for (int x = 0; x < tentLength; x++)
                    {
                        for (int z = 0; z < tentWidth; z++)
                        {
                            if (structuremap.coord2ID[ranSWCoord.x + x, ranSWCoord.y + z] != -1)
                            {
                                canCreate = false;
                            }
                        }
                    }
                    if (canCreate)
                    {
                        for (int x = 0; x < tentLength; x++)
                        {
                            for (int z = 0; z < tentWidth; z++)
                            {
                                structuremap.coord2ID[ranSWCoord.x + x, ranSWCoord.y + z] = index;
                            }
                        }
                        structuremap.id2Structure.Add(tent);
                    }
                }
            }

            yield return structuremap;
        }

    }
}
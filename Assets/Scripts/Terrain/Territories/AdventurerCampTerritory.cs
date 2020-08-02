using Core;
using System.Collections;
using System.Collections.Generic;

namespace Terrain
{
    internal class AdventurerCampTerritory : Territory
    {
        private int seed;

        public AdventurerCampTerritory(int seed) : base()
        {
            this.seed = seed;
        }

        public override int Range { get { return 16; } }

        public override IEnumerator<Structuremap> GenerateStructuremap()
        {
            {
                //在中心创建一个篝火
                var bonfire = new Bonfire();
                var swCoord = new Coord2Int(Pivot2Int.x - bonfire.Pivot2Int.x, Pivot2Int.y - bonfire.Pivot2Int.y);
                var index = id2Structure.Count;
                for (int x = 0; x < bonfire.Data.GetLength(0); x++)
                {
                    for (int z = 0; z < bonfire.Data.GetLength(2); z++)
                    {
                        structuremap[swCoord.x + x, swCoord.y + z] = index;
                    }
                }
                id2Structure.Add(bonfire);
            }

            //尝试创建4个帐篷
            var factor = seed;
            for (int i = 0; i < 4; i++)
            {
                var index = id2Structure.Count;
                var tent = new Tent(--factor, seed);

                var tentLength = tent.Data.GetLength(0);
                var tentWidth = tent.Data.GetLength(2);
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
                        if (structuremap[ranSWCoord.x + x, ranSWCoord.y + z] != -1)
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
                            structuremap[ranSWCoord.x + x, ranSWCoord.y + z] = index;
                        }
                    }
                    id2Structure.Add(tent);
                }

            }

            yield return null;
        }

    }
}
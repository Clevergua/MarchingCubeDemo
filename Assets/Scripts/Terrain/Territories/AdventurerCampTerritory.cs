using Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    internal class AdventurerCampTerritory : Territory
    {
        public override int Range { get { return 16; } }
        public override void GenerateStructuremap(Environmentmap environmentmap, int seed)
        {
            var s = RNG.Random2(IslandCoord.x, IslandCoord.y, seed);
            structuremap = new Structuremap(Length, Length);
            //在中心创建一个篝火
            {
                var bonfire = new Bonfire();
                var swCoord = new Coord2Int(Pivot2Int.x - bonfire.Pivot2Int.x, Pivot2Int.y - bonfire.Pivot2Int.y);
                var result = structuremap.TryAddStructure(bonfire, swCoord);
                if (!result) throw new Exception($"建筑篝火预设体过大");
            }

            //尝试创建4个帐篷
            {
                var factor = s;
                for (int i = 0; i < 4; i++)
                {
                    var tent = new Tent(++factor, s);
                    var rx = RNG.Random1(++factor, s) % (Length - tent.Length);
                    var rz = RNG.Random1(++factor, s) % (Length - tent.Width);
                    rx = rx > 0 ? rx : -rx;
                    rz = rz > 0 ? rz : -rz;
                    var swCoord = new Coord2Int(rx, rz);
                    structuremap.TryAddStructure(tent, swCoord);
                }
            }
        }
    }
}
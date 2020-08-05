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
                var factor = seed;
                for (int i = 0; i < 4; i++)
                {
                    var tent = new Tent(factor++, seed);
                    var rx = RNG.Random1(factor++, seed) % (Length - tent.Length);
                    var rz = RNG.Random1(factor++, seed) % (Length - tent.Width);
                    rx = rx > 0 ? rx : -rx;
                    rz = rz > 0 ? rz : -rz;
                    var swCoord = new Coord2Int(rx, rz);
                    structuremap.TryAddStructure(tent, swCoord);
                }
            }
        }

        internal override void GeneratePathmap()
        {
            var markedTerritories = new List<Territory>();
            var unmarkedTerritories = new List<Territory>();
            BossTerritory bossTerritory = null;
            foreach (var t in id2Territory)
            {
                if (t is AdventurerCampTerritory)
                {
                    markedTerritories.Add(t);
                }
                else
                {
                    if (t is BossTerritory)
                    {
                        bossTerritory = t as BossTerritory;
                    }
                    else
                    {
                        unmarkedTerritories.Add(t);
                    }
                }
            }
            yield return null;

            unmarkedTerritories.Add(bossTerritory);
            while (unmarkedTerritories.Count > 0)
            {
                var currentMarkedTerritory = markedTerritories[markedTerritories.Count - 1];
                var minDistance = int.MaxValue;
                Territory destination = null;
                var minDisUnmarkedTerritoryIndex = -1;
                for (int i = 0; i < unmarkedTerritories.Count; i++)
                {
                    var unmarkedTerritory = unmarkedTerritories[i];
                    var distance = Mathf.Abs(currentMarkedTerritory.WorldCoord.x - unmarkedTerritory.WorldCoord.x) + Mathf.Abs(currentMarkedTerritory.WorldCoord.y - unmarkedTerritory.WorldCoord.y);
                    if (distance < minDistance)
                    {
                        destination = unmarkedTerritory;
                        minDisUnmarkedTerritoryIndex = i;
                        minDistance = distance;
                    }
                }

                minDistance = int.MaxValue;
                Territory departure = null;
                foreach (var markedTerritory in markedTerritories)
                {
                    var distance = Mathf.Abs(markedTerritory.WorldCoord.x - destination.WorldCoord.x) + Mathf.Abs(markedTerritory.WorldCoord.y - destination.WorldCoord.y);
                    if (distance < minDistance)
                    {
                        departure = markedTerritory;
                        minDistance = distance;
                    }
                }

                markedTerritories.Add(destination);
                unmarkedTerritories.RemoveAt(minDisUnmarkedTerritoryIndex);
                var coords = GenerateCoordsOnPathByAStar(departure.WorldCoord, destination.WorldCoord, territorymap);
                paths.Add(new Path(departure, destination, coords));
                yield return null;
            }
        }
    }
}
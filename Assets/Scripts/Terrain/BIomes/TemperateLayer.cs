using System.Collections.Generic;
namespace Terrain
{
    public class TemperateLayer : Biome
    {
        public TemperateLayer()
        {
        }

        internal override Island GetEndingIsland(int seed)
        {
            return new PrairieCampIsland();
        }

        internal override Island GetStartingIsland(int seed)
        {
            return new PrairieCampIsland();
        }
        internal override IEnumerable<Island> GetSpecialIslands(int seed)
        {
            var list = new List<Island>();
            //list.Add(new PrairieCampIsland());
            return list;
        }
    }
}
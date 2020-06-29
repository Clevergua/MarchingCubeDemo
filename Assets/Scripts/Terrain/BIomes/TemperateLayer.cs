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
            throw new System.NotImplementedException();
        }

        internal override Island GetStartingIsland(int seed)
        {
            throw new System.NotImplementedException();
        }
        internal override IEnumerable<Island> GetSpecialIslands(int seed)
        {
            throw new System.NotImplementedException();
        }
    }
}
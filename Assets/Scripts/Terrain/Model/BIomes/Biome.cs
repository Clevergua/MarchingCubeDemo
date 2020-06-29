using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Biome
{
    internal abstract Island GetStartingIsland(int seed);
    internal abstract Island GetEndingIsland(int seed);
    internal abstract IEnumerable<Island> GetSpecialIslands(int seed);
}

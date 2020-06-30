using Core.Math;
using System;
using System.Collections.Generic;

namespace Terrain
{
    public class TerrainGenerator
    {
        public Layer CreateLayer(int seed, int worldLength, Biome biome)
        {
            var length = worldLength * Constants.ChunkLength;
            var height = Constants.WorldHeight * Constants.ChunkLength;
            var coord2BlockID = new int[length, height, length];
            var coord2Island = new Island[worldLength, worldLength];
            var islands = FillCoord2Island(coord2Island, seed, biome);
            for (int chunkX = 0; chunkX < worldLength; chunkX++)
            {
                for (int chunkZ = 0; chunkZ < worldLength; chunkZ++)
                {
                    var island = coord2Island[chunkX, chunkZ];
                    for (int chunkY = 0; chunkY < Constants.WorldHeight; chunkY++)
                    {
                        var blocksOfChunk = island.GetCoord2BlockIDOfChunk(chunkX, chunkY, chunkZ);
                        FillCoord2BlockID(coord2BlockID, blocksOfChunk, chunkX, chunkY, chunkZ);
                    }
                }
            }
            return new Layer(coord2BlockID, islands);
        }


        private void FillCoord2BlockID(int[,,] coord2BlockID, int[,,] blocksOfChunk, int chunkX, int chunkY, int chunkZ)
        {
            for (int localBlockX = 0; localBlockX < Constants.ChunkLength; localBlockX++)
            {
                for (int localBlockZ = 0; localBlockZ < Constants.ChunkLength; localBlockZ++)
                {
                    for (int localBlockY = 0; localBlockY < Constants.ChunkLength; localBlockY++)
                    {
                        var blockX = chunkX * Constants.ChunkLength + localBlockX;
                        var blockY = chunkY * Constants.ChunkLength + localBlockY;
                        var blockZ = chunkZ * Constants.ChunkLength + localBlockZ;
                        coord2BlockID[blockX, blockY, blockZ] = blocksOfChunk[localBlockX, localBlockY, localBlockZ];
                    }
                }
            }
        }
        private IReadOnlyList<Island> FillCoord2Island(Island[,] coord2Island, int seed, Biome biome)
        {
            var islands = new List<Island>();

            var masks = new Coord2Int[] { Coord2Int.zero, Coord2Int.right, Coord2Int.one, Coord2Int.up };
            var startingDir = RNG.Random1(0, seed) % 4;
            var step = 3;
            var startingMask = masks[startingDir];
            var endingMask = masks[startingDir + step];

            var startingIsland = biome.GetStartingIsland(seed);
            var startingNECoord = new Coord2Int(coord2Island.GetLength(0) - 1 - startingIsland.Length, coord2Island.GetLength(1) - 1 - startingIsland.Length);
            var startingCoord = new Coord2Int(startingNECoord.x * startingMask.x, startingNECoord.y * startingNECoord.y);
            if (TryAddIsland(coord2Island, startingIsland, startingCoord))
            {
                islands.Add(startingIsland);
            }
            else
            {
                throw new Exception("The size of the world is not big enough!");
            }

            var endingIsland = biome.GetEndingIsland(seed);
            var endingNECoord = new Coord2Int(coord2Island.GetLength(0) - 1 - endingIsland.Length, coord2Island.GetLength(1) - 1 - endingIsland.Length);
            var endingCoord = new Coord2Int(endingNECoord.x * endingMask.x, endingNECoord.y * endingMask.y);
            if (TryAddIsland(coord2Island, endingIsland, endingCoord))
            {
                islands.Add(endingIsland);
            }
            else
            {
                throw new Exception("The size of the world is not big enough!");
            }

            var specialIslands = biome.GetSpecialIslands(seed);
            var factor = 0;
            foreach (var i in specialIslands)
            {
                var x = RNG.Random1(factor, seed);
                factor = x;
                x %= coord2Island.GetLength(0);

                var y = RNG.Random1(factor, seed);
                factor = y;
                y %= coord2Island.GetLength(1);

                var coord = new Coord2Int(x, y);
                var numOfAttempts = 0;
                while (!TryAddIsland(coord2Island, i, coord))
                {
                    numOfAttempts++;
                    if (numOfAttempts > 1024)
                    {
                        throw new Exception("The size of the world is not big enough!");
                    }
                }
                islands.Add(i);
            }

            return islands;
        }
        private bool TryAddIsland(Island[,] coord2Island, Island island, Coord2Int coord)
        {
            for (int x = coord.x; x < island.Length + coord.x; x++)
            {
                for (int z = coord.y; z < island.Length + coord.y; z++)
                {
                    if (x < coord2Island.GetLength(0) && z < coord2Island.GetLength(1))
                    {
                        if (coord2Island[x, z] != null)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            for (int x = coord.x; x < island.Length + coord.x; x++)
            {
                for (int z = coord.y; z < island.Length + coord.y; z++)
                {
                    coord2Island[x, z] = island;
                    island.SouthwestChunkCoord = new Coord2Int(x, z);
                }
            }
            return true;
        }
    }
}

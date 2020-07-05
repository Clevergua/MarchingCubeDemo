using Core.Math;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    public class TerrainGenerator
    {
        public Layer CreateLayer(int seed, int worldLength, Biome biome)
        {
            var length = worldLength * Constants.ChunkLength;
            var height = Constants.WorldHeight * Constants.ChunkLength;

            var heightmap = new int[length, length];
            var temperaturemap = new int[length, length];
            var humiditymap = new int[length, length];

            var structuremap = new int[length, length];
            var structures = new List<Structure>();
            var blockmap = new int[length, height, length];

            FillEnvironmentalMaps(seed, length, heightmap, temperaturemap, humiditymap);

            //Fill structuremap:
            var masks = new Coord2Int[] { Coord2Int.zero, Coord2Int.right, Coord2Int.one, Coord2Int.up };
            var startingDir = RNG.Random1(8945, seed) % 4;
            var step = 2;
            var startingMask = masks[startingDir];
            var endingMask = masks[startingDir + step];
            var halfLength = length / 2;
            var startingMovement = new Coord2Int(RNG.Random1(7485, seed)% halfLength, RNG.Random1(415, seed));
            var endingMovement = new Coord2Int(RNG.Random1(87, seed), RNG.Random1(257, seed));




            //var islandmap = new Island[worldLength, worldLength];
            //var islands = FillIslandmap(islandmap, seed, biome);

            //for (int chunkx = 0; chunkx < worldLength; chunkx++)
            //{
            //    for (int chunkz = 0; chunkz < worldLength; chunkz++)
            //    {
            //        var island = islandmap[chunkx, chunkz];
            //        var verticalChunkCoord = new Coord2Int(chunkx, chunkz);
            //        var verticalBlockmap = island.GetVerticalBlockmap(verticalChunkCoord, seed);
            //        FillBlockmap(blockmap, verticalBlockmap, verticalChunkCoord);
            //    }
            //}
            //return new Layer(blockmap, islands);
            return new Layer(null, null);
        }

        private void FillEnvironmentalMaps(int seed, int length, int[,] heightmap, int[,] temperaturemap, int[,] humiditymap)
        {
            for (int x = 0; x < length; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    var heightNoiseDensity = 0.0003f;
                    var heightNoise = PerlinNoise.PerlinNoise2D(seed + 1232, x * heightNoiseDensity, z * heightNoiseDensity) * 0.5f + 0.5f;
                    heightmap[x, z] = (int)(Mathf.Lerp(Constants.MinHeight, Constants.MaxHeight, heightNoise));

                    var temperatureNoiseDensity = 0.0007f;
                    var temperatureNoise = PerlinNoise.PerlinNoise2D(seed + 8674, x * temperatureNoiseDensity, z * temperatureNoiseDensity) * 0.5f + 0.5f;
                    temperaturemap[x, z] = (int)(Mathf.Lerp(Constants.MinTemperature, Constants.MaxTemperature, temperatureNoise));

                    var humidityNoiseDensity = 0.0007f;
                    var humidityNoise = PerlinNoise.PerlinNoise2D(seed + 96, x * humidityNoiseDensity, z * humidityNoiseDensity) * 0.5f + 0.5f;
                    humiditymap[x, z] = (int)(Mathf.Lerp(Constants.MinHumidity, Constants.MaxHumidity, humidityNoise));
                }
            }
        }



        //private void FillBlockmap(int[,,] coord2BlockID, int[,,] verticalBlockmap, Coord2Int verticalChunkCoord)
        //{
        //    for (int localBlockx = 0; localBlockx < Constants.ChunkLength; localBlockx++)
        //    {
        //        for (int localBlockz = 0; localBlockz < Constants.ChunkLength; localBlockz++)
        //        {
        //            for (int worldBlocky = 0; worldBlocky < Constants.ChunkLength * Constants.WorldHeight; worldBlocky++)
        //            {
        //                var worldBlockx = verticalChunkCoord.x * Constants.ChunkLength + localBlockx;
        //                var worldBlockz = verticalChunkCoord.y * Constants.ChunkLength + localBlockz;
        //                coord2BlockID[worldBlockx, worldBlocky, worldBlockz] = verticalBlockmap[localBlockx, worldBlocky, localBlockz];
        //            }
        //        }
        //    }
        //}
        //private IReadOnlyList<Island> FillIslandmap(Island[,] coord2Island, int seed, Biome biome)
        //{
        //    var islands = new List<Island>();

        //    var masks = new Coord2Int[] { Coord2Int.zero, Coord2Int.right, Coord2Int.one, Coord2Int.up };
        //    var startingDir = RNG.Random1(0, seed) % 4;
        //    var step = 3;
        //    var startingMask = masks[startingDir];
        //    var endingMask = masks[startingDir + step];

        //    var startingIsland = biome.GetStartingIsland(seed);
        //    var startingNECoord = new Coord2Int(coord2Island.GetLength(0) - 1 - startingIsland.Length, coord2Island.GetLength(1) - 1 - startingIsland.Length);
        //    var startingCoord = new Coord2Int(startingNECoord.x * startingMask.x, startingNECoord.y * startingMask.y);
        //    if (TryAddIsland(coord2Island, startingIsland, startingCoord))
        //    {
        //        islands.Add(startingIsland);
        //    }
        //    else
        //    {
        //        throw new Exception("The size of the world is not big enough!");
        //    }

        //    var endingIsland = biome.GetEndingIsland(seed);
        //    var endingNECoord = new Coord2Int(coord2Island.GetLength(0) - 1 - endingIsland.Length, coord2Island.GetLength(1) - 1 - endingIsland.Length);
        //    var endingCoord = new Coord2Int(endingNECoord.x * endingMask.x, endingNECoord.y * endingMask.y);
        //    if (TryAddIsland(coord2Island, endingIsland, endingCoord))
        //    {
        //        islands.Add(endingIsland);
        //    }
        //    else
        //    {
        //        throw new Exception("The size of the world is not big enough!");
        //    }

        //    var specialIslands = biome.GetSpecialIslands(seed);
        //    var factor = 0;
        //    foreach (var i in specialIslands)
        //    {
        //        var x = RNG.Random1(factor, seed);
        //        factor = x;
        //        x %= coord2Island.GetLength(0);

        //        var y = RNG.Random1(factor, seed);
        //        factor = y;
        //        y %= coord2Island.GetLength(1);

        //        var coord = new Coord2Int(x, y);
        //        var numOfAttempts = 0;
        //        while (!TryAddIsland(coord2Island, i, coord))
        //        {
        //            numOfAttempts++;
        //            if (numOfAttempts > 1024)
        //            {
        //                throw new Exception("The size of the world is not big enough!");
        //            }
        //        }
        //        islands.Add(i);
        //    }

        //    return islands;
        //}
        //private bool TryAddIsland(Island[,] coord2Island, Island island, Coord2Int coord)
        //{
        //    for (int x = coord.x; x < island.Length + coord.x; x++)
        //    {
        //        for (int z = coord.y; z < island.Length + coord.y; z++)
        //        {
        //            if (x < coord2Island.GetLength(0) && z < coord2Island.GetLength(1))
        //            {
        //                if (coord2Island[x, z] != null)
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    for (int x = coord.x; x < island.Length + coord.x; x++)
        //    {
        //        for (int z = coord.y; z < island.Length + coord.y; z++)
        //        {
        //            coord2Island[x, z] = island;
        //        }
        //    }
        //    island.SouthwestChunkCoord = coord;
        //    return true;
        //}
    }
}

using Core.Math;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Terrain
{
    public class PrairieCampIsland : Island
    {
        private static readonly int length = 2;
        internal override int Length { get { return length; } }

        protected override int[,,] GenerateVerticalBlockmap(Coord2Int worldChunkCoord, int seed, int[,] heightmap)
        {
            var verticalBlockmap = new int[Constants.ChunkLength, Constants.ChunkLength * Constants.WorldHeight, Constants.ChunkLength];
            var centerHeight = heightmap[LocalVerticalCenterBlockCoord.x, LocalVerticalCenterBlockCoord.y];
            //island surface center point
            var centerBlockCoord = new Coord3Int(WorldVerticalCenterBlockCoord.x, centerHeight, WorldVerticalCenterBlockCoord.y);
            for (int localBlockx = 0; localBlockx < verticalBlockmap.GetLength(0); localBlockx++)
            {
                for (int localBlockz = 0; localBlockz < verticalBlockmap.GetLength(2); localBlockz++)
                {
                    var currentHeight = heightmap[localBlockx, localBlockz];
                    for (int worldBlocky = 0; worldBlocky < verticalBlockmap.GetLength(1); worldBlocky++)
                    {
                        var worldBlockCoord = new Coord3Int(worldChunkCoord.x * Constants.ChunkLength + localBlockx, worldBlocky, worldChunkCoord.y * Constants.ChunkLength + localBlockz);
                       
                        //Shape terrain by heightmap
                        if (worldBlocky <= currentHeight)
                        {
                            verticalBlockmap[localBlockx, worldBlocky, localBlockz] = 1;
                        }
                        else
                        {
                            verticalBlockmap[localBlockx, worldBlocky, localBlockz] = 0;
                        }

                        var noiseSmapleDensity = 0.03f;
                        //-1~1
                        var noiseValue = PerlinNoise.PerlinNoise3D(seed, worldBlockCoord.x * noiseSmapleDensity, worldBlockCoord.y * noiseSmapleDensity, worldBlockCoord.z * noiseSmapleDensity);
                        //Use the current height to process noise, the further away from the current height, the smaller the noise impact, and vice versa.
                        var maxDifference = 4;
                        noiseValue *= Mathf.Lerp(0, 1, maxDifference - Mathf.Abs(worldBlocky - currentHeight));

                        //Shape terrain by noise
                        if (noiseValue < -0.5f)
                        {
                            verticalBlockmap[localBlockx, worldBlocky, localBlockz] = 0;
                        }
                        else if (noiseValue > 0.5f)
                        {
                            verticalBlockmap[localBlockx, worldBlocky, localBlockz] = 1;
                        }
                        else
                        {
                            //Do nothing..
                        }
                    }
                }
            }
            return verticalBlockmap;
        }
    }
}
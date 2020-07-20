using UnityEngine;
using System.Collections;
namespace Terrain
{
    public static class Constants
    {
        public static readonly int ChunkLength = 16;
        public static readonly int WorldHeight = 16;

        public static readonly int MinHeight = 64;
        public static readonly int MaxHeight = 128;

        public static readonly int MinTemperature = 0;
        public static readonly int MaxTemperature = 100;

        public static readonly int MinHumidity = 0;
        public static readonly int MaxHumidity = 100;

        public static readonly int LayerEdgeWidth = 32;

        public static readonly int MinNormalTerritoryCount = 6;
        public static readonly int MaxNormalTerritoryCount = 8;

        public static readonly int PathRange = 8;

        public static readonly int HeightNoiseImpactRange = 32;
    }
}

using Core;

namespace Terrain
{
    public class Island
    {
        public byte this[int x, int y, int z] { get => blockmap[x, y, z]; }
        private int horizontalChunkCount;
        private int verticalChunkCount;
        private Environmentmap environmentmap;
        private Territorymap territorymap;
        private Pathmap pathmap;
        private byte[,,] blockmap;

        internal Island(Environmentmap environmentmap, Territorymap territorymap, Pathmap pathmap, byte[,,] blockmap, int horizontalChunkCount, int verticalChunkCount)
        {
            this.horizontalChunkCount = horizontalChunkCount;
            this.verticalChunkCount = verticalChunkCount;
            this.environmentmap = environmentmap;
            this.territorymap = territorymap;
            this.pathmap = pathmap;
            this.blockmap = blockmap;
        }

        public bool InRange(int x, int y, int z)
        {
            return (x >= 0 && y >= 0 && z >= 0 && x < blockmap.GetLength(0) && y < blockmap.GetLength(1) && z < blockmap.GetLength(2));
        }
        public int HorizontalChunkCount { get => horizontalChunkCount; }
        public int VerticalChunkCount { get => verticalChunkCount; }
    }
}
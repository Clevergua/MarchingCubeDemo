namespace Terrain
{
    public class Island
    {
        private int horizontalChunkCount;
        private int verticalChunkCount;
        private Environmentmap environmentmap;
        private Territorymap territorymap;
        private Pathmap pathmap;
        private byte[,,] blockmap;

        public Island(Environmentmap environmentmap, Territorymap territorymap, Pathmap pathmap, byte[,,] blockmap, int horizontalChunkCount, int verticalChunkCount)
        {
            this.horizontalChunkCount = horizontalChunkCount;
            this.verticalChunkCount = verticalChunkCount;
            this.environmentmap = environmentmap;
            this.territorymap = territorymap;
            this.pathmap = pathmap;
            this.blockmap = blockmap;
        }

        public byte[,,] Blockmap { get => blockmap; }
        public int HorizontalChunkCount { get => horizontalChunkCount; }
        public int VerticalChunkCount { get => verticalChunkCount; }
    }
}
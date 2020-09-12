using Core;
using System.Collections.Generic;
using Terrain;
using UnityEngine;


public class IslandView : MonoBehaviour
{
    private ChunkView[,,] coord2ChunkView;
    [SerializeField]
    private GameObject chunkViewPrefab;
    public void Init(Island island, List<Color> blockID2Color)
    {
        coord2ChunkView = new ChunkView[island.HorizontalChunkCount, island.VerticalChunkCount, island.HorizontalChunkCount];
        for (int x = 0; x < island.HorizontalChunkCount; x++)
        {
            for (int z = 0; z < island.HorizontalChunkCount; z++)
            {
                for (int y = 0; y < island.VerticalChunkCount; y++)
                {
                    coord2ChunkView[x, y, z] = Instantiate(chunkViewPrefab, transform, true).GetComponent<ChunkView>();
                    coord2ChunkView[x, y, z].Draw(new Coord3Int(x, y, z), island, blockID2Color);
                }
            }
        }
    }
}

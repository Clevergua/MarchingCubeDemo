using Terrain;
using UnityEngine;


public class IslandView : MonoBehaviour
{
    private ChunkView[,] chunkmap;
    public void Init(Island island)
    {
        chunkmap = new ChunkView[island.islandLength, island.islandLength];
        for (int x = 0; x < island.islandLength; x++)
        {
            for (int y = 0; y < island.islandLength; y++)
            {
                chunkmap[x, y] = new GameObject().AddComponent<ChunkView>();
            }
        }


    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

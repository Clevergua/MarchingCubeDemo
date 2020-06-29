using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Math;

public class LandView : MonoBehaviour
{
    [SerializeField] GameObject chunkViewPrefab;
    [SerializeField] List<BlockViewData> blockViewDatas;
    ChunkView[,,] chunkViews;
    public void Init(LandVM landVM)
    {
        chunkViews = new ChunkView[landVM.Length, landVM.Height, landVM.Length];
        for (int x = 0; x < landVM.Length; x++)
        {
            for (int z = 0; z < landVM.Length; z++)
            {
                for (int y = 0; y < landVM.Height; y++)
                {
                    var coord3 = new Coord3Int(x, y, z);
                    var chunkView = Instantiate(chunkViewPrefab, transform).GetComponent<ChunkView>();
                    chunkView.Init(coord3, landVM, blockViewDatas);
                    chunkViews[x, y, z] = chunkView;
                }
            }
        }
    }
}

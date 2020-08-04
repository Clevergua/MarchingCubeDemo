using System.Collections;
using System.Collections.Generic;
using Terrain;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    private int seed;
    Island terrainGen;
    [SerializeField] Text text;
    [SerializeField] List<GameObject> prefabs;
    private bool hasShown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Create level
        terrainGen = new Island();
        terrainGen.
        //StartCoroutine(terrainGen.TTT());
    }
    IEnumerator Show()
    {
        var l = terrainGen.result;
        for (int x = 0 + 1; x < l.blockmap.GetLength(0) - 1; x++)
        {
            var parent = new GameObject();
            for (int y = 0 + 1; y < l.blockmap.GetLength(1) - 1; y++)
            {
                for (int z = 0 + 1; z < l.blockmap.GetLength(2) - 1; z++)
                {
                    if (l.blockmap[x, y, z] == (byte)BlockType.Air)
                    {

                    }
                    else
                    {
                        if (l.blockmap[x + 1, y, z] != (byte)BlockType.Air && l.blockmap[x - 1, y, z] != (byte)BlockType.Air && l.blockmap[x, y + 1, z] != (byte)BlockType.Air && l.blockmap[x, y - 1, z] != (byte)BlockType.Air && l.blockmap[x, y, z - 1] != (byte)BlockType.Air && l.blockmap[x, y, z + 1] != (byte)BlockType.Air)
                        {

                        }
                        else
                        {
                            Instantiate(prefabs[l.blockmap[x, y, z]], new Vector3(x, y, z), Quaternion.identity, parent.transform);
                        }
                        if (true)
                        {

                        }
                    }
                }
            }
            StaticBatchingUtility.Combine(parent);
            yield return null;
        }
    }
    private void Update()
    {
        //text.text = $"{terrainGen.currentOperation}::{terrainGen.progress}";
        //if (terrainGen.isDone && !hasShown)
        //{
        //    hasShown = true;
        //    StartCoroutine(Show());
        //}
    }
}

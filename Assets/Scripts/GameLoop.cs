using System.Collections;
using Terrain;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    private int seed;
    private Layer l;
    TerrainGenerator terrainGen;
    [SerializeField] Text text;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject pathPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Create level
        terrainGen = new TerrainGenerator();
        var seed = Random.Range(int.MinValue, int.MaxValue);
        Debug.Log(seed);
        StartCoroutine(terrainGen.GenerateLayer(0, 16, () =>
        {
            l = terrainGen.result;
            StartCoroutine(Show());
        }));
    }
    IEnumerator Show()
    {
        for (int x = 0 + 1; x < l.blockmap.GetLength(0) - 1; x++)
        {
            var parent = new GameObject();
            for (int y = 0 + 1; y < l.blockmap.GetLength(1) - 1; y++)
            {
                for (int z = 0 + 1; z < l.blockmap.GetLength(2) - 1; z++)
                {
                    if (l.blockmap[x, y, z] == 0)
                    {

                    }
                    else
                    {
                        if (l.blockmap[x + 1, y, z] != 0 && l.blockmap[x - 1, y, z] != 0 && l.blockmap[x, y + 1, z] != 0 && l.blockmap[x, y - 1, z] != 0 && l.blockmap[x, y, z - 1] != 0 && l.blockmap[x, y, z + 1] != 0)
                        {

                        }
                        else
                        {
                            if (l.blockmap[x, y, z] == 1)
                            {
                                var go = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity, parent.transform);
                            }
                            else if (l.blockmap[x, y, z] == 2)
                            {
                                var go = Instantiate(waterPrefab, new Vector3(x, y, z), Quaternion.identity, parent.transform);
                            }
                            else if (l.blockmap[x, y, z] == 3)
                            {
                                var go = Instantiate(pathPrefab, new Vector3(x, y, z), Quaternion.identity, parent.transform);
                            }
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
        text.text = $"{terrainGen.currentOperation}::{terrainGen.progress}";

    }
}

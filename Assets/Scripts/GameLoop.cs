using System.Collections;
using Terrain;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private int seed;
    private Layer l;
    // Start is called before the first frame update
    void Start()
    {
        //Create level
        var terrainGen = new TerrainGenerator();
        var seed = Random.Range(int.MinValue, int.MaxValue);
        Debug.Log(seed);
        l = terrainGen.CreateLayer(0, 32);
        StartCoroutine(Show());

    }
    IEnumerator Show()
    {
        for (int x = 0 + 1; x < l.blockmap.GetLength(0) - 1; x++)
        {
            for (int y = 0 + 1; y < l.blockmap.GetLength(1) - 1; y++)
            {
                for (int z = 0 + 1; z < l.blockmap.GetLength(2) - 1; z++)
                {
                    if (l.blockmap[x, y, z] == 0)
                    {

                    }
                    else
                    {
                        if (l.blockmap[x + 1, y, z] == 1 && l.blockmap[x - 1, y, z] == 1 && l.blockmap[x, y + 1, z] == 1 && l.blockmap[x, y - 1, z] == 1 && l.blockmap[x, y, z - 1] == 1 && l.blockmap[x, y, z + 1] == 1)
                        {

                        }
                        else
                        {
                            var c = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            c.transform.position = new Vector3(x, y, z);
                        }
                    }
                }

            }
            yield return null;
        }
    }
    private void Update()
    {


    }
}

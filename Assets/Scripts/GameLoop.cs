using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terrain;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    [SerializeField] int seed;
    [SerializeField] Text text;
    [SerializeField] List<Color> block2Color;
    private Task<Island> task;
    // Start is called before the first frame update
    void Start()
    {
        seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        var generator = new IslandGenerator();
        task = Task.Run(() =>
        {
            return generator.GenerateAsync(seed, 16);
        });
    }
    IEnumerator Show()
    {
        var blockmap = task.Result.Blockmap;
        for (int x = 0 + 1; x < blockmap.GetLength(0) - 1; x++)
        {
            var parent = new GameObject();
            for (int y = 0 + 1; y < blockmap.GetLength(1) - 1; y++)
            {
                for (int z = 0 + 1; z < blockmap.GetLength(2) - 1; z++)
                {
                    if (blockmap[x, y, z] == (byte)BlockType.Air)
                    {

                    }
                    else
                    {
                        if (blockmap[x + 1, y, z] != (byte)BlockType.Air && blockmap[x - 1, y, z] != (byte)BlockType.Air && blockmap[x, y + 1, z] != (byte)BlockType.Air && blockmap[x, y - 1, z] != (byte)BlockType.Air && blockmap[x, y, z - 1] != (byte)BlockType.Air && blockmap[x, y, z + 1] != (byte)BlockType.Air)
                        {

                        }
                        else
                        {
                            CreateBlock(blockmap[x, y, z], new Vector3(x, y, z), parent.transform);
                        }
                    }
                }
            }
            StaticBatchingUtility.Combine(parent);
            yield return null;
        }
    }
    private void CreateBlock(byte v, Vector3 position, Transform parent)
    {
        //var newMesh = new Mesh();
        //newMesh.vertices = mesh.vertices;
        //newMesh.triangles = mesh.triangles;
        //var colors = new Color[mesh.vertices.Length];
        //for (int i = 0; i < colors.Length; i++)
        //{
        //    colors[i] = block2Color[v];
        //}
        //newMesh.colors = colors;
        //var go = new GameObject();
        //var mf = go.AddComponent<MeshFilter>();
        //mf.sharedMesh = newMesh;
        //var mr = go.AddComponent<MeshRenderer>();
        //mr.material = material;
        //go.transform.position = position;
        //go.transform.SetParent(parent);
    }
    private void Update()
    {
        //text.text = $"{generator.currentOperation}:{generator.isDone}";
        //if (generator.isDone && !hasShown)
        //{
        //    hasShown = true;
        //    StartCoroutine(Show());
        //}
    }
}

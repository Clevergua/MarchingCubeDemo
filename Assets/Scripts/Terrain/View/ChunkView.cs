using Math;
using System.Collections.Generic;
using UnityEngine;


public class ChunkView : MonoBehaviour
{
    private Dictionary<Material, MCRenderer> material2MCRenderer;
    [SerializeField] GameObject mcRendererPrefab;
    public void Init(Coord3Int coord, LandVM landVM, IReadOnlyList<BlockViewData> id2BlockViewData)
    {
        material2MCRenderer = new Dictionary<Material, MCRenderer>();
        var chunkLength = landVM.ChunkLength;
        var ldbCoord = coord * chunkLength;
        for (int x = ldbCoord.x; x < ldbCoord.x + chunkLength; x++)
        {
            for (int z = ldbCoord.z; z < ldbCoord.z + chunkLength; z++)
            {
                for (int y = ldbCoord.y; y < ldbCoord.y + chunkLength; y++)
                {
                    if (landVM.ContainsCoord(x + 1, y + 1, z + 1))
                    {
                        var coordOffset = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);

                        var ldbID = landVM.GetBlockID(x, y, z);
                        var ldfID = landVM.GetBlockID(x, y, z + 1);
                        var rdfID = landVM.GetBlockID(x + 1, y, z + 1);
                        var rdbID = landVM.GetBlockID(x + 1, y, z);

                        var lubID = landVM.GetBlockID(x, y + 1, z);
                        var lufID = landVM.GetBlockID(x, y + 1, z + 1);
                        var rufID = landVM.GetBlockID(x + 1, y + 1, z + 1);
                        var rubID = landVM.GetBlockID(x + 1, y + 1, z);

                        var input = new bool[]
                        {
                            ldbID != 0, ldfID != 0, rdfID != 0, rdbID != 0,
                            lubID != 0, lufID != 0, rufID != 0, rubID != 0
                        };

                        var blockViewDatas = new BlockViewData[]
                        {
                            id2BlockViewData[ldbID],
                            id2BlockViewData[ldfID],
                            id2BlockViewData[rdfID],
                            id2BlockViewData[rdbID],

                            id2BlockViewData[lubID],
                            id2BlockViewData[lufID],
                            id2BlockViewData[rufID],
                            id2BlockViewData[rubID],
                        };

                        var index2Vertices = ColorfulMC.GetIndexToVertices(input);
                        var index2Normals = ColorfulMC.GetIndexToNormals(input);
                        foreach (var index in index2Vertices.Keys)
                        {
                            var data = blockViewDatas[index];
                            MCRenderer renderer;
                            if (material2MCRenderer.ContainsKey(data.Material))
                            {
                                renderer = material2MCRenderer[data.Material];
                            }
                            else
                            {
                                renderer = Instantiate(mcRendererPrefab, transform).GetComponent<MCRenderer>();
                                renderer.Material = data.Material;
                                material2MCRenderer.Add(data.Material, renderer);

                            }
                            var colors = new Color[index2Vertices[index].Length];
                            for (int i = 0; i < colors.Length; i++)
                            {
                                colors[i] = data.Color;
                            }
                            var vertices = new Vector3[index2Vertices[index].Length];
                            for (int i = 0; i < index2Vertices[index].Length; i++)
                            {
                                vertices[i] = index2Vertices[index][i] + coordOffset;
                            }
                            renderer.AddMesh(vertices, index2Normals[index], colors);
                        }
                    }
                    else
                    {
                        //数据不足
                    }
                }
            }
        }
        foreach (var renderer in material2MCRenderer.Values)
        {
            renderer.Show();
        }
    }
}
using Core;
using System.Collections.Generic;
using Terrain;
using UnityEngine;


public class ChunkView : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    private void Awake()
    {
        meshFilter.mesh = new Mesh();
    }
    public void Draw(Coord3Int coord, Island island, List<Color> blockID2Color)
    {
        var chunkLength = IslandGenerator.ChunkLength;
        var ldbCoord = coord * chunkLength;

        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var colors = new List<Color>();

        for (int x = ldbCoord.x; x < ldbCoord.x + chunkLength; x++)
        {
            for (int z = ldbCoord.z; z < ldbCoord.z + chunkLength; z++)
            {
                for (int y = ldbCoord.y; y < ldbCoord.y + chunkLength; y++)
                {
                    if (island.InRange(x + 1, y + 1, z + 1))
                    {
                        var coordOffset = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);

                        var ids = new byte[]
                        {
                            island[x, y, z],
                            island[x, y, z + 1],
                            island[x + 1, y, z + 1],
                            island[x + 1, y, z],
                            island[x, y + 1, z],
                            island[x, y + 1, z + 1],
                            island[x + 1, y + 1, z + 1],
                            island[x + 1, y + 1, z]
                        };
                        var air = (byte)BlockType.Air;
                        var input = new bool[]
                        {
                            ids[0] != air, ids[1] != air, ids[2] != air, ids[3] != air,
                            ids[4] != air, ids[5] != air, ids[6] != air, ids[7] != air
                        };

                        var index2Vertices = ColorfulMC.GetIndexToVertices(input);
                        var index2Normals = ColorfulMC.GetIndexToNormals(input);

                        foreach (var index in index2Vertices.Keys)
                        {
                            var curVertices = index2Vertices[index];
                            var currentNormals = index2Normals[index];
                            var color = blockID2Color[ids[index]];
                            for (int i = 0; i < curVertices.Length; i++)
                            {
                                colors.Add(color);
                            }
                            for (int i = 0; i < curVertices.Length; i++)
                            {
                                var v = curVertices[i] + coordOffset;
                                vertices.Add(v);
                            }
                            normals.AddRange(currentNormals);
                        }
                    }
                    else
                    {
                        //越界不处理
                    }
                }
            }
        }
        if (vertices.Count > 0)
        {
            meshFilter.mesh.SetVertices(vertices);
            meshFilter.mesh.SetNormals(normals);
            meshFilter.mesh.SetColors(colors);

            List<int> triangles = new List<int>(vertices.Count);
            for (int i = 0; i < vertices.Count; i++)
            {
                triangles.Add(i);
            }
            meshFilter.mesh.SetTriangles(triangles, 0);
        }
    }
}
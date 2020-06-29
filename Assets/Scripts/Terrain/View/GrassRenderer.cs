using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Math;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GrassRenderer : MonoBehaviour
{
    [SerializeField] Material material;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private List<Vector3> vertices;
    private List<int> triangles;
    private List<Vector2> uv1s;
    public void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        vertices = new List<Vector3>();
        triangles = new List<int>();
        uv1s = new List<Vector2>();
    }
    public void AddGrass(Coord3Int coord3Int)
    {
        var length = 10;
        for (int x = 0; x < length; x++)
        {
            for (int z = 0; z < length; z++)
            {
                Vector3 v = new Vector3(x * 1 / length, 0, z * 1 / length);
                uv1s.Add(new Vector2(UnityEngine.Random.Range(0, 1000) * 0.001f, UnityEngine.Random.Range(0, 1000) * 0.001f));

                vertices.Add(v);
                if (x == 0 || z == 0) continue;
                triangles.Add(length * x + z);
                triangles.Add(length * x + z - 1);
                triangles.Add(length * (x - 1) + z - 1);
                triangles.Add(length * (x - 1) + z - 1);
                triangles.Add(length * (x - 1) + z);
                triangles.Add(length * x + z);
            }
        }
    }
    public void Show()
    {
        meshFilter.mesh.SetVertices(vertices);
        meshFilter.mesh.SetTriangles(triangles, 0);
        meshFilter.mesh.SetUVs(1, uv1s);
    }
}

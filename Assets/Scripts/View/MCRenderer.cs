using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
internal class MCRenderer : MonoBehaviour
{
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private List<Vector3> vertices;
    private List<Vector3> normals;
    private List<Color> colors;
    private Material material;
    public Material Material { get => material; set => material = value; }

    public void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        vertices = new List<Vector3>();
        normals = new List<Vector3>();
        colors = new List<Color>();
    }

    public void AddMesh(Vector3[] vertices, Vector3[] normals, Color[] colors)
    {
        this.vertices.AddRange(vertices);
        this.normals.AddRange(normals);
        this.colors.AddRange(colors);
    }
    public void ClearMesh()
    {
        this.vertices.Clear();
        this.normals.Clear();
        this.colors.Clear();
    }

    public void Show()
    {
        meshFilter.mesh = new Mesh();
        List<int> triangles = new List<int>(vertices.Count);
        for (int i = 0; i < vertices.Count; i++)
        {
            triangles.Add(i);
        }
        meshFilter.mesh.SetVertices(vertices);
        meshFilter.mesh.SetNormals(normals);
        meshFilter.mesh.SetColors(colors);
        meshFilter.mesh.SetTriangles(triangles, 0);

        meshRenderer.sharedMaterial = material;
    }
}
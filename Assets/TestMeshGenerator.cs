using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMeshGenerator : MonoBehaviour
{
    [SerializeField] private int length;
    [SerializeField] private float detail;
    // Start is called before the first frame update
    void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();

        List<Vector3> inVertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv1s = new List<Vector2>();

        for (int x = 0; x < length; x++)
        {
            for (int z = 0; z < length; z++)
            {
                Vector3 v = new Vector3(x * detail, 0, z * detail);
                uv1s.Add(new Vector2(Random.Range(0, 1000) * 0.001f, Random.Range(0, 1000) * 0.001f));
                inVertices.Add(v);
                if (x == 0 || z == 0) continue;
                triangles.Add(length * x + z);
                triangles.Add(length * x + z - 1);
                triangles.Add(length * (x - 1) + z - 1);
                triangles.Add(length * (x - 1) + z - 1);
                triangles.Add(length * (x - 1) + z);
                triangles.Add(length * x + z);
            }
        }
        meshFilter.mesh.SetVertices(inVertices);
        meshFilter.mesh.SetTriangles(triangles, 0);
        meshFilter.mesh.SetUVs(1, uv1s);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

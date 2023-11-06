using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator: MonoBehaviour
{
    private Mesh mesh;
    public GameObject prefab;

    public void GenerateMesh(List<Vector3> vertices, List<int> triangles)
    {
        mesh = new Mesh
        {
            vertices = vertices.ToArray(),
            triangles = triangles.ToArray()
        };

        mesh.RecalculateNormals();
    }

    public Transform InstantiateMesh(Vector3 position, Transform parent)
    {
        var obj = Instantiate(prefab, position, Quaternion.identity, parent);
        obj.GetComponent<MeshFilter>().mesh = mesh;

        return obj.transform;
    }

}

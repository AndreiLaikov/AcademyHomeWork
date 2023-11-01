using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    public float size;
    private float vertexCoord;

    private Mesh mesh;
    private MeshFilter filter;



    private void Start()
    {
        filter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;
    }

    private void CalculateCoordinates()
    {
        vertexCoord = size * Mathf.Sqrt(2) / 2;
    }

    private Vector3[] GenerateVertices()
    {
        return new Vector3[]
        {
            new Vector3(-vertexCoord,-vertexCoord,-vertexCoord),//0
            new Vector3(-vertexCoord,vertexCoord,-vertexCoord),//1
            new Vector3(vertexCoord,-vertexCoord,-vertexCoord),//2
            new Vector3(vertexCoord,vertexCoord,-vertexCoord),//3
            new Vector3(-vertexCoord,vertexCoord,vertexCoord),//4
            new Vector3(vertexCoord,vertexCoord,vertexCoord),//5
            new Vector3(vertexCoord,-vertexCoord,vertexCoord),//6
            new Vector3(-vertexCoord,-vertexCoord,vertexCoord)//7
        };
    }

    private int[] GenerateTriangles()
    {
        return new int[]
        {
            //front
            0,1,2,
            1,3,2,
            //left
            7,1,0,
            4,1,7,
            //top
            1,4,3,
            4,5,3,
            //right
            2,3,6,
            3,5,6,
            //back
            6,4,7,
            6,5,4,
            //bottom
            7,0,2,
            7,2,6
        };
    }

    private Vector2[] GenerateUv()
    {
        return new Vector2[]
        {

        };
    }

    [ContextMenu("Generate")]
    public void GenerateMesh()
    {
        CalculateCoordinates();

        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.RecalculateNormals();
    }
    /*             4-------5
                  /       /|
                 /       / |
                1-------3  |
                |   7   |  /6
                |       | /
                |       |/
                0-------2   
     
      --- 0
      -+- 1
      +-- 2
      ++- 3
      -++ 4
      +++ 5
      +-+ 6
      --+ 7     

       */
}

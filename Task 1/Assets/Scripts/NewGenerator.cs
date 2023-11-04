using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class NewGenerator : MonoBehaviour
{
    public Vector3 sizes;

    private float xHalf;
    private float yHalf;
    private float zHalf;


    private Mesh mesh;
    private MeshFilter filter;

    List<Vector3> vert = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uv = new List<Vector2>();


    private void OnEnable()
    {
        filter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        filter.mesh = mesh;
        Debug.Log("Start");
    }

    private void CalculateCoordinates()
    {

        xHalf = sizes.x / 2;
        yHalf = sizes.y / 2;
        zHalf = sizes.z / 2;

    }

    void GenerateUVs()
    {
        uv.Add(new Vector2(0, 0));
        uv.Add(new Vector2(0, 1));
        uv.Add(new Vector2(1, 0));
        uv.Add(new Vector2(1, 1));
    }

    private void GenerateFront()
    {
        vert.Add(new Vector3(-1*xHalf, -1*yHalf, -1*zHalf));//0
        vert.Add(new Vector3(-1*xHalf, 1*yHalf, -1*zHalf));//1
        vert.Add(new Vector3(1*xHalf, -1*yHalf, -1*zHalf));//2
        vert.Add(new Vector3(1*xHalf, 1*yHalf, -1*zHalf));//3

        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);

        triangles.Add(1);
        triangles.Add(3);
        triangles.Add(2);

        GenerateUVs();
    }

    private void GenerateTop()
    {
        vert.Add(new Vector3(-1*xHalf, 1*yHalf, -1 * zHalf));//1 - 4
        vert.Add(new Vector3(-1*xHalf, 1*yHalf, 1*zHalf));//4 - 5
        vert.Add(new Vector3(1*xHalf, 1*yHalf, -1*zHalf));//3 - 6
        vert.Add(new Vector3(1*xHalf, 1*yHalf, 1 * zHalf));//5 - 7

        triangles.Add(4);
        triangles.Add(5);
        triangles.Add(6);

        triangles.Add(5);
        triangles.Add(7);
        triangles.Add(6);

        GenerateUVs();
    }

    private void GenerateBack()
    {
        vert.Add(new Vector3(-1*xHalf, -1 * yHalf, 1 * zHalf));//7 - 8
        vert.Add(new Vector3(-1*xHalf, 1*yHalf, 1* zHalf));//4 - 9
        vert.Add(new Vector3(1*xHalf, -1*yHalf, 1* zHalf));//6 - 10
        vert.Add(new Vector3(1*xHalf, 1 * yHalf, 1 * zHalf));//5 - 11

        triangles.Add(10);
        triangles.Add(11);
        triangles.Add(9);

        triangles.Add(8);
        triangles.Add(10);
        triangles.Add(9);

        GenerateUVs();
    }

    private void GenerateBottom()
    {
        vert.Add(new Vector3(-1*xHalf, -1*yHalf, -1 * zHalf));//0 - 12
        vert.Add(new Vector3(-1*xHalf, -1*yHalf, 1* zHalf));//7 - 13
        vert.Add(new Vector3(1*xHalf, -1*yHalf, -1* zHalf));//2 - 14
        vert.Add(new Vector3(1*xHalf, -1*yHalf, 1 * zHalf));//6 - 15

        triangles.Add(13);
        triangles.Add(12);
        triangles.Add(14);

        triangles.Add(13);
        triangles.Add(14);
        triangles.Add(15);

        GenerateUVs();
    }

    private void GenerateLeft()
    {

        vert.Add(new Vector3(-1*xHalf, -1 * yHalf, 1 * zHalf));//7 - 16 
        vert.Add(new Vector3(-1*xHalf, 1 * yHalf, 1 * zHalf));//4 - 17
        vert.Add(new Vector3(-1*xHalf, -1 * yHalf, -1 * zHalf));//0 - 18
        vert.Add(new Vector3(-1*xHalf, 1 * yHalf, -1 * zHalf));//1 - 19

        triangles.Add(16);
        triangles.Add(17);
        triangles.Add(18);

        triangles.Add(17);
        triangles.Add(19);
        triangles.Add(18);

        GenerateUVs();
    }

    private void GenerateRight()
    {
        vert.Add(new Vector3(1*xHalf, -1 * yHalf, -1 * zHalf));//2 -20
        vert.Add(new Vector3(1*xHalf, 1 * yHalf, -1* zHalf));//3 - 21
        vert.Add(new Vector3(1*xHalf, -1 * yHalf, 1* zHalf));//6 - 22
        vert.Add(new Vector3(1*xHalf, 1 * yHalf, 1 * zHalf));//5 - 23


        triangles.Add(20);
        triangles.Add(21);
        triangles.Add(22);

        triangles.Add(21);
        triangles.Add(23);
        triangles.Add(22);

        GenerateUVs();
    }

    [ContextMenu("Generate")]
    public void GenerateMesh()
    {
        vert = new List<Vector3>();
        triangles = new List<int>();
        uv = new List<Vector2>();

        CalculateCoordinates();

        GenerateFront();
        GenerateTop();
        GenerateBack();
        GenerateBottom();
        GenerateLeft();
        GenerateRight();

        mesh.vertices = vert.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        mesh.RecalculateNormals();
    }



    /*             4-------5
                  /       /|
                 /       / |
                1-------3  |
                |   7   |  /6
             y  |       | / z
                |       |/
                0-------2   
                    x
      --- 0
      -+- 1
      +-- 2
      ++- 3
      -++ 4
      +++ 5
      +-+ 6
      --+ 7     

    4---1
    |   |
    7---0

       */
}

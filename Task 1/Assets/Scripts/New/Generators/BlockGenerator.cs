using System.Collections.Generic;
using UnityEngine;

namespace StackApp.Generators
{
    public class BlockGenerator
    {
        private Vector3 halfSize;

        private const int vertexCount = 24;
        private const int triangleCount = 36;

        private List<Vector3> vertices = new(vertexCount);
        private List<int> triangles = new(triangleCount);


        public Mesh GenerateBlock(Vector3 size)
        {
            CalculateCoordinates(size);
            CalculateMesh();

            Mesh blockMesh = new()
            {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray()
            };

            blockMesh.RecalculateNormals();

            return blockMesh;
        }

        private void CalculateCoordinates(Vector3 size)
        {
            var xHalf = size.x / 2;
            var yHalf = size.y / 2;
            var zHalf = size.z / 2;

            halfSize = new Vector3(xHalf, yHalf, zHalf);
        }

        public void CalculateMesh()
        {
            CalculateFront();
            CalculateTop();
            CalculateBack();
            CalculateBottom();
            CalculateLeft();
            CalculateRight();
        }

        private void CalculateFront()
        {
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, -1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, 1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, -1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, 1, -1)));

            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(2);

            triangles.Add(1);
            triangles.Add(3);
            triangles.Add(2);
        }

        private void CalculateTop()
        {
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, 1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, 1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, 1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, 1, 1)));

            triangles.Add(4);
            triangles.Add(5);
            triangles.Add(6);

            triangles.Add(5);
            triangles.Add(7);
            triangles.Add(6);
        }

        private void CalculateBack()
        {
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, -1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, 1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, -1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, 1, 1)));

            triangles.Add(10);
            triangles.Add(11);
            triangles.Add(9);

            triangles.Add(8);
            triangles.Add(10);
            triangles.Add(9);
        }

        private void CalculateBottom()
        {
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, -1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, -1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, -1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, -1, 1)));

            triangles.Add(13);
            triangles.Add(12);
            triangles.Add(14);

            triangles.Add(13);
            triangles.Add(14);
            triangles.Add(15);
        }

        private void CalculateLeft()
        {
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, -1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, 1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, -1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(-1, 1, -1)));

            triangles.Add(16);
            triangles.Add(17);
            triangles.Add(18);

            triangles.Add(17);
            triangles.Add(19);
            triangles.Add(18);
        }

        private void CalculateRight()
        {
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, -1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, 1, -1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, -1, 1)));
            vertices.Add(Vector3.Scale(halfSize, new Vector3(1, 1, 1)));

            triangles.Add(20);
            triangles.Add(21);
            triangles.Add(22);

            triangles.Add(21);
            triangles.Add(23);
            triangles.Add(22);
        }
    }
}
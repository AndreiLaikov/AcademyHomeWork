using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackApp.Generators
{
    public class BlockCalculator
    {
        private float xHalf;
        private float yHalf;
        private float zHalf;

        private List<Vector3> vertices = new List<Vector3>();
        private List<int> triangles = new List<int>();

        private void CalculateCoordinates(Vector3 size)
        {
            xHalf = size.x / 2;
            yHalf = size.y / 2;
            zHalf = size.z / 2;
        }

        private void CalculateFront()
        {
            vertices.Add(new Vector3(-1 * xHalf, -1 * yHalf, -1 * zHalf));//0
            vertices.Add(new Vector3(-1 * xHalf, 1 * yHalf, -1 * zHalf));//1
            vertices.Add(new Vector3(1 * xHalf, -1 * yHalf, -1 * zHalf));//2
            vertices.Add(new Vector3(1 * xHalf, 1 * yHalf, -1 * zHalf));//3
           
            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(2);

            triangles.Add(1);
            triangles.Add(3);
            triangles.Add(2);
        }

        private void CalculateTop()
        {
            vertices.Add(new Vector3(-1 * xHalf, 1 * yHalf, -1 * zHalf));//1 - 4
            vertices.Add(new Vector3(-1 * xHalf, 1 * yHalf, 1 * zHalf));//4 - 5
            vertices.Add(new Vector3(1 * xHalf, 1 * yHalf, -1 * zHalf));//3 - 6
            vertices.Add(new Vector3(1 * xHalf, 1 * yHalf, 1 * zHalf));//5 - 7

            triangles.Add(4);
            triangles.Add(5);
            triangles.Add(6);

            triangles.Add(5);
            triangles.Add(7);
            triangles.Add(6);
        }

        private void CalculateBack()
        {
            vertices.Add(new Vector3(-1 * xHalf, -1 * yHalf, 1 * zHalf));//7 - 8
            vertices.Add(new Vector3(-1 * xHalf, 1 * yHalf, 1 * zHalf));//4 - 9
            vertices.Add(new Vector3(1 * xHalf, -1 * yHalf, 1 * zHalf));//6 - 10
            vertices.Add(new Vector3(1 * xHalf, 1 * yHalf, 1 * zHalf));//5 - 11

            triangles.Add(10);
            triangles.Add(11);
            triangles.Add(9);

            triangles.Add(8);
            triangles.Add(10);
            triangles.Add(9);
        }

        private void CalculateBottom()
        {
            vertices.Add(new Vector3(-1 * xHalf, -1 * yHalf, -1 * zHalf));//0 - 12
            vertices.Add(new Vector3(-1 * xHalf, -1 * yHalf, 1 * zHalf));//7 - 13
            vertices.Add(new Vector3(1 * xHalf, -1 * yHalf, -1 * zHalf));//2 - 14
            vertices.Add(new Vector3(1 * xHalf, -1 * yHalf, 1 * zHalf));//6 - 15

            triangles.Add(13);
            triangles.Add(12);
            triangles.Add(14);

            triangles.Add(13);
            triangles.Add(14);
            triangles.Add(15);
        }

        private void CalculateLeft()
        {

            vertices.Add(new Vector3(-1 * xHalf, -1 * yHalf, 1 * zHalf));//7 - 16 
            vertices.Add(new Vector3(-1 * xHalf, 1 * yHalf, 1 * zHalf));//4 - 17
            vertices.Add(new Vector3(-1 * xHalf, -1 * yHalf, -1 * zHalf));//0 - 18
            vertices.Add(new Vector3(-1 * xHalf, 1 * yHalf, -1 * zHalf));//1 - 19

            triangles.Add(16);
            triangles.Add(17);
            triangles.Add(18);

            triangles.Add(17);
            triangles.Add(19);
            triangles.Add(18);
        }

        private void CalculateRight()
        {
            vertices.Add(new Vector3(1 * xHalf, -1 * yHalf, -1 * zHalf));//2 -20
            vertices.Add(new Vector3(1 * xHalf, 1 * yHalf, -1 * zHalf));//3 - 21
            vertices.Add(new Vector3(1 * xHalf, -1 * yHalf, 1 * zHalf));//6 - 22
            vertices.Add(new Vector3(1 * xHalf, 1 * yHalf, 1 * zHalf));//5 - 23


            triangles.Add(20);
            triangles.Add(21);
            triangles.Add(22);

            triangles.Add(21);
            triangles.Add(23);
            triangles.Add(22);
        }

        public void CalculateMesh(Vector3 size, out List<Vector3> vertList, out List<int> triangleList)
        {
            CalculateCoordinates(size);
           
            CalculateFront();
            CalculateTop();
            CalculateBack();
            CalculateBottom();
            CalculateLeft();
            CalculateRight();

            vertList = vertices;
            triangleList = triangles;

        }
    }
}
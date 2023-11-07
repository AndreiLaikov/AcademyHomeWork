using System.Collections.Generic;
using UnityEngine;

namespace StackApp.Generators
{
    public class BlockGenerator
    {
        [SerializeField] private Mesh blockMesh;

        public Mesh GenerateBlock(List<Vector3> vertices, List<int> triangles)
        {
            blockMesh = new Mesh
            {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray()
            };
            blockMesh.RecalculateNormals();
            return blockMesh;
        }
    }
}
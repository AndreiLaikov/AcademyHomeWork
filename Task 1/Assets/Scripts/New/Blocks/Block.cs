using UnityEngine;
using StackApp.Generators;
using System.Collections.Generic;

namespace StackApp.Block
{
    public class Block : MonoBehaviour
    {
        private GameConfigurationDataBlock configuration;
        private BlockCalculator calculator;
        private BlockGenerator generator;

        private BlockElement block;

        public void SpawnBlock(Vector3 size, Transform parent)
        {
            List<Vector3> vertices;
            List<int> triangles;

            calculator.CalculateMesh(size, out vertices, out triangles);

            block = Instantiate(configuration.blockPrefab, configuration.InitialPosition, Quaternion.identity, parent);

            block.BlockMesh.mesh = generator.GenerateBlock(vertices, triangles);
            block.BlockCollider.size = size;
        }
    }
}
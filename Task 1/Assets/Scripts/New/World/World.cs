using System.Collections.Generic;
using StackApp.Block;
using UnityEngine;

namespace StackApp.World
{
    public class World : MonoBehaviour
    {
        private GameConfigurationDataWorld worldConfiguration;
        private GameConfigurationDataBlock blockConfiguration;
        private BlockElement worldElement;
        private Generators.BlockCalculator calculator;
        private Generators.BlockGenerator generator;

        public void Initialize(GameConfigurationDataWorld worldConfig, GameConfigurationDataBlock blockConfig)
        {
            worldConfiguration = worldConfig;
            blockConfiguration = blockConfig;
            calculator = new Generators.BlockCalculator();
            generator = new Generators.BlockGenerator();

            SpawnWorld(worldConfiguration.WorldParentTransform);
        }

        private Vector3 CalculateSize()
        {
            var sizeY = Mathf.Abs(worldConfiguration.StartingBoxPosition.y * 2 + blockConfiguration.InitialSize.y / 2);
            return new Vector3(blockConfiguration.InitialSize.x, sizeY, blockConfiguration.InitialSize.z);
        }

        public void SpawnWorld(Transform parent)
        {
            List<Vector3> vertices;
            List<int> triangles;
            Vector3 size = CalculateSize();

            calculator.CalculateMesh(size,out vertices,out triangles);

            worldElement = Instantiate(blockConfiguration.blockPrefab, worldConfiguration.StartingBoxPosition, Quaternion.identity, parent);

            worldElement.BlockMesh.mesh = generator.GenerateBlock(vertices, triangles);
            worldElement.BlockCollider.size = size;
        }
    }
}
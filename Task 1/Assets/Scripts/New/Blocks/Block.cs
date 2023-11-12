using UnityEngine;
using StackApp.Generators;

namespace StackApp.Blocks
{
    public class Block: BlockElement
    {
        public Vector3 BlockSize;
        private GameConfigurationDataBlock config;
        private BlockGenerator generator;

        public Block(GameConfigurationDataBlock blockConfiguration)
        {
            config = blockConfiguration;
            generator = new BlockGenerator();
        }

        public Block SpawnBlock(Vector3 size, Vector3 position,Color color)
        {
            BlockSize = size;

            var block = Instantiate(config.BlockPrefab, position, Quaternion.identity, config.BlocksParentTransform);
            block.BlockMesh.mesh = generator.GenerateBlock(size);
            block.BlockCollider.size = size;
            block.BlockMaterial.color = color;

            return block;
        }
    }
}
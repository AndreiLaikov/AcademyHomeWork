using UnityEngine;
using StackApp.Generators;

namespace StackApp.Blocks
{
    public class Block: BlockElement
    {
        private BlockGenerator generator;

        public void CreateBlock(Vector3 size, Vector3 position, Color color)
        {
            generator = new BlockGenerator();
            BlockMesh.mesh = generator.GenerateBlock(size);
            BlockCollider.size = size;
            BlockRenderer.material.color = color;
            transform.position = position;
        }

        public void CreateMovingBlock(Vector3 size, Vector3 position, Color color, GameConfigurationDataMover moverConfiguration)
        {
            CreateBlock(size, position, color);

            var moverConfig = moverConfiguration;
            var mover = gameObject.AddComponent<BlockMover>();
            mover.Amplitude = moverConfig.MovingAmplitude;
            mover.Speed = moverConfig.Speed;
        }

        public void CreateFallingBlock(Vector3 size, Vector3 position, Color color)
        {
            CreateBlock(size, position, color);
            RBody.isKinematic = false;
            gameObject.AddComponent<BlockDestroyer>();
        }

        public void BlockDestroy()
        {
            Destroy(gameObject);
        }
    }
}
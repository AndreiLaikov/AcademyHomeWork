using UnityEngine;

namespace StackApp.Blocks
{
    public class MovingBlock : MonoBehaviour
    {
        private Block block;

        public Block SpawnMovingBlock(GameConfigurationDataMover moverConfig, GameConfigurationDataBlock blockConfig, Vector3 size, Vector3 position, Color color)
        {
            block = new Block(blockConfig);
            block = block.SpawnBlock(size, position, color);

            block.gameObject.AddComponent<BlockMover>();
            SetMovingValue(moverConfig);

            return block;
        }

        private void SetMovingValue(GameConfigurationDataMover config)
        {
            block.GetComponent<BlockMover>().Amplitude = config.MovingAmplitude;
            block.GetComponent<BlockMover>().Speed = config.Speed;
        }
    }
}
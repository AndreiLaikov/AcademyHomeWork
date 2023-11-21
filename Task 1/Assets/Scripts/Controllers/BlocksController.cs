using UnityEngine;
using StackApp.Blocks;
using StackApp.Generators;

namespace StackApp
{
    public class BlocksController : MonoBehaviour
    {
        private GameConfigurationDataBlock blockConfig;
        private GameConfigurationDataMover moverConfig;
        private CuttingCalculator.MeshesData calculateData;

        private Block currentMovingBlock;
        private Block currentPlayableBlock;
        private Vector3 currentPlayableSize;
        private Color currentColor;

        public void Initialize(GameConfigurationData configuration, Block startingBlock)
        {
            blockConfig = configuration.BlockConfiguration;
            moverConfig = configuration.MoverConfiguration;

            currentPlayableBlock = startingBlock;
            currentPlayableSize = blockConfig.InitialSize;
            calculateData = new CuttingCalculator.MeshesData();
        }

        public void GenerateMovingBlock(Vector3 position)
        {
            if (currentMovingBlock != null)
            {
                currentMovingBlock.BlockDestroy();
            }

            currentMovingBlock = CreateInstance();
            currentMovingBlock.CreateMovingBlock(currentPlayableSize, position, currentColor, moverConfig);
        }

        public bool IsBlockCutting()
        {
            calculateData = CuttingCalculator.Calculate(currentPlayableBlock.transform, currentMovingBlock.transform, currentPlayableSize);
            return calculateData.PlayableSize.x > 0;
        }

        public void GenerateBlocks()
        {
            currentPlayableBlock = CreateInstance();
            currentPlayableBlock.CreateBlock(calculateData.PlayableSize, calculateData.PlayablePosition, currentColor);
            currentPlayableSize = calculateData.PlayableSize;

            var fallingBlock = CreateInstance();
            fallingBlock.CreateFallingBlock(calculateData.FallingSize, calculateData.FallingPosition, currentColor);
        }

        public void GenerateLosingBlock()
        {
            var lastPosition = currentMovingBlock.transform.position;
            currentMovingBlock.BlockDestroy();

            currentPlayableBlock = CreateInstance();
            currentPlayableBlock.CreateFallingBlock(currentPlayableSize, lastPosition, currentColor);
        }

        public void SetColor(Color color)
        {
            currentColor = color;
        }

        private Block CreateInstance()
        {
            return Instantiate(blockConfig.BlockPrefab, blockConfig.BlocksParentTransform);
        } 
    }
}

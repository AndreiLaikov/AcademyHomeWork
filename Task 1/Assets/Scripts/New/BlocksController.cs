using UnityEngine;
using StackApp.Blocks;
using StackApp.Generators;

namespace StackApp
{
    public class BlocksController
    {
        private GameConfigurationData configuration;
        private CuttingCalculator cuttingCalculator;
        private CuttingCalculator.MeshesData calculateData;

        private MovingBlock currentMovingBlock;
        private Block currentPlayableBlock;
        private Vector3 currentPlayableSize;
        private Color currentColor;

        public int PlayableBlocksCount;

        public void Initialize(GameConfigurationData config, Block startingBlock, Color color)
        {   
            configuration = config;
            PlayableBlocksCount = 0;
            cuttingCalculator = new CuttingCalculator();
            currentPlayableBlock = startingBlock;
            currentPlayableSize = startingBlock.BlockSize;
            currentColor = color;
        }

        public void SpawnMovingBlock(Vector3 size, Vector3 position)
        {
            PlayableBlocksCount++;
            currentColor = CalculateColor();
            currentMovingBlock = new MovingBlock();
            currentMovingBlock.SpawnMovingBlock(configuration.MoverConfiguration, configuration.BlockConfiguration, size, position,currentColor);
        }

        public void CutBlock()
        {
            calculateData = cuttingCalculator.Calculate(currentPlayableBlock.transform, currentMovingBlock.transform, currentPlayableSize);

            if (calculateData.PlayableSize.x < 0)
                Debug.Log("End");//todo gameover
        }

        public void GenerateBlocks()
        {
            currentPlayableBlock.SpawnBlock(calculateData.PlayableSize, calculateData.PlayablePosition,currentColor);

            var fallingBlock = new Block(configuration.BlockConfiguration);
            fallingBlock.SpawnBlock(calculateData.FallingSize, calculateData.FallingPosition,currentColor);
            fallingBlock.RBody.isKinematic = false;
        }

        private Color CalculateColor()
        {
            float currentHue = (PlayableBlocksCount % 36)/ 36;
            Color.RGBToHSV(currentColor, out float hue, out float saturation, out float value);

            return Color.HSVToRGB(currentHue, saturation, value);
        }
    }
}

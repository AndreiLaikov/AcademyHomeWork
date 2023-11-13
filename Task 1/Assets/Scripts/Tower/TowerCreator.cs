using UnityEngine;

namespace StackApp.Tower
{
    public class TowerCreator
    {
        private GameConfigurationDataBlock blockConfig;
        private BlocksController blocksController;
        public int PlayableBlocksCount;

        public void Initialize(GameConfigurationDataBlock blockConfiguration, BlocksController blocksController)
        {
            blockConfig = blockConfiguration;
            this.blocksController = blocksController;
            PlayableBlocksCount = 0;
            blocksController.SetColor(CalculateColor());
        }

        public void TryToCreate()
        {
            if (blocksController.IsBlockCutting())
            {
                CreateBlocks();
            }
            else
            {
                blocksController.GenerateLosingBlock();
                EventController.PlaceWrong();
            }
        }

        private void CreateBlocks()
        {
            PlayableBlocksCount++;
            blocksController.GenerateBlocks();
            blocksController.SetColor(CalculateColor());
            blocksController.GenerateMovingBlock(PositionCalculate());

            EventController.PlaceRight();
        }

        private Vector3 PositionCalculate()
        {
            var yPosition = blockConfig.InitialPosition.y + blockConfig.InitialSize.y * PlayableBlocksCount;
            return blockConfig.InitialPosition + Vector3.up * yPosition;
        }

        private Color CalculateColor()
        {
            float currentHue = (float)PlayableBlocksCount % 36 / 36;
            Color.RGBToHSV(blockConfig.initialColor, out float hue, out float saturation, out float value);

            return Color.HSVToRGB(currentHue, saturation, value);
        }
    }
}

using StackApp.Blocks;
using UnityEngine;

namespace StackApp.World
{
    public class World
    {
        private GameConfigurationDataBlock blockConfig;
        private GameConfigurationDataWorld worldConfig;
        public Block worldBlock;

        public void Initialize(GameConfigurationDataBlock blockConfiguration, GameConfigurationDataWorld worldConfiguration)
        {
            blockConfig = blockConfiguration;
            worldConfig = worldConfiguration;
            SpawnWorld();//create a start big block in StartingBoxPos 
        }

        private void SpawnWorld()
        {
            worldBlock = new Block(blockConfig);
            worldBlock = worldBlock.SpawnBlock(CalculateSize(), blockConfig.StartingBoxPosition, worldConfig.initialColor);
            worldBlock.name = "World";
        }

        private Vector3 CalculateSize()//Calculate size of world box by length and width = InitialSize and height = 2*Y - (blocks height)/2
        {
            var sizeY = Mathf.Abs(blockConfig.StartingBoxPosition.y * 2) - blockConfig.InitialSize.y / 2;
            return new Vector3(blockConfig.InitialSize.x, sizeY, blockConfig.InitialSize.z);
        }
    }
}
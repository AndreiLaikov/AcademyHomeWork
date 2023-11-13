using StackApp.Blocks;
using UnityEngine;

namespace StackApp.World
{
    public class World : MonoBehaviour
    {
        private GameConfigurationDataBlock blockConfig;
        public Block worldBlock;

        public void Initialize(GameConfigurationDataBlock blockConfiguration)
        {
            blockConfig = blockConfiguration;
            SpawnWorld();//create a start big block in StartingBoxPos 
        }

        private void SpawnWorld()
        {
            worldBlock = Instantiate(blockConfig.BlockPrefab, blockConfig.BlocksParentTransform);
            worldBlock.CreateBlock(CalculateSize(), blockConfig.StartingBoxPosition, blockConfig.initialColor);
        }

        private Vector3 CalculateSize()//Calculate size of world box by length and width = InitialSize and height = 2*Y - (blocks height)/2
        {
            var sizeY = Mathf.Abs(blockConfig.StartingBoxPosition.y * 2) - blockConfig.InitialSize.y / 2;
            return new Vector3(blockConfig.InitialSize.x, sizeY, blockConfig.InitialSize.z);
        }
    }
}
using UnityEngine;

namespace StackApp
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameConfigurationData configuration;
        private World.World world;
        private BlocksController blocksController;
        private Player.Player player;

        private void Start()
        {
            InitGame();
        }

        private void InitGame()
        {
            world = new World.World();
            world.Initialize(configuration.BlockConfiguration, configuration.WorldConfiguration);

            blocksController = new BlocksController();
            blocksController.Initialize(configuration, world.worldBlock, configuration.WorldConfiguration.initialColor);

            player = new Player.Player();
        }

        private void StartGame()
        {
            blocksController.SpawnMovingBlock(configuration.BlockConfiguration.InitialSize, configuration.BlockConfiguration.InitialPosition);
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;
using StackApp.Tower;

namespace StackApp
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private UI.UiController uiController;
        [SerializeField] private GameConfigurationData configuration;
        private World.World world;
        private BlocksController blocksController;
        private Player.Player player;
        private PlayerInput input;
        private TowerCreator tower;
        private CameraController.CameraController cameraController;
        private Transform blocksParentTransform;

        private void Start()
        {
            player = gameObject.AddComponent<Player.Player>();
            cameraController = gameObject.AddComponent<CameraController.CameraController>();
            cameraController.Initialize(configuration.WorldConfiguration, configuration.BlockConfiguration);

            InitGame();
            EventController.OnGameStarting += StartGame;
            EventController.OnGameRestarting += RestartGame;
            EventController.OnBlockRightPlacing += OnBlockRightPlacing;
            EventController.OnBlockWrongPlacing += OnBlockWrongPlacing;
        }

        private void InitGame()
        {
            blocksParentTransform = new GameObject("[World]").transform;
            configuration.BlockConfiguration.BlocksParentTransform = blocksParentTransform;

            world = gameObject.AddComponent<World.World>();
            world.Initialize(configuration.BlockConfiguration);

            blocksController = gameObject.AddComponent<BlocksController>();
            blocksController.Initialize(configuration, world.worldBlock);

            tower = new TowerCreator();
            tower.Initialize(configuration.BlockConfiguration, blocksController);

            player.Initialize(tower);
            uiController.Initialize(player);
        }

        private void StartGame()
        {
            blocksController.GenerateMovingBlock(configuration.BlockConfiguration.InitialPosition);

            input = new PlayerInput();
            input.Enable();
            input.Player.Tap.performed += TapPerformed;
        }

        private void RestartGame()
        {
            RemoveInitComponents();
            InitGame();
        }

        private void RemoveInitComponents()
        {
            Destroy(blocksParentTransform.gameObject);
            Destroy(player);
            Destroy(blocksController);
            Destroy(world);
        }

        private void OnBlockWrongPlacing()
        {
            input.Disable();
            uiController.ShowRestartUi();
        }

        private void OnBlockRightPlacing()
        {
            player.AddScore();
            uiController.ChangeScore();
        }

        private void TapPerformed(InputAction.CallbackContext obj)
        {
            tower.TryToCreate();
        }

        private void OnDestroy()
        {
            EventController.OnGameStarting -= StartGame;
            EventController.OnGameRestarting -= RestartGame;
            EventController.OnBlockRightPlacing -= OnBlockRightPlacing;
            EventController.OnBlockWrongPlacing -= OnBlockWrongPlacing;
        }
    }
}
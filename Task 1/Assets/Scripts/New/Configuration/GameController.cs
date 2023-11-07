using UnityEngine;

namespace StackApp
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameConfigurationData configuration;
        private World.World world;

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            world = gameObject.AddComponent<World.World>();
            world.Initialize(configuration.WorldConfiguration,configuration.BlockConfiguration);
        }
    }
}
using System.Collections;
using UnityEngine;

namespace StackApp.CameraController
{
    public class CameraController : MonoBehaviour
    {
        private Camera camera;
        private GameConfigurationDataWorld worldConfig;
        private GameConfigurationDataBlock blockConfig;
       
        public void Initialization(GameConfigurationDataWorld worldConfiguration, GameConfigurationDataBlock blockConfiguration)
        {
            camera = Camera.main;
            worldConfig = worldConfiguration;
            blockConfig = blockConfiguration;
            camera.transform.position = worldConfig.CameraStartPosition;
            camera.transform.rotation = Quaternion.Euler(worldConfig.CameraStartRotation);
            EventController.OnGameStarting += GameStarting;
            EventController.OnGameRestarting += OnGameRestarting;
            EventController.OnBlockRightPlacing += OnBlockRightPlacing;
        }

        private IEnumerator CameraMove(Vector3 target)
        {
            while (Vector3.Distance(camera.transform.position, target) > float.Epsilon)
            {
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, target, worldConfig.CameraSpeed * Time.deltaTime);
                yield return null;
            }
        }

        private void OnBlockRightPlacing()
        {
            var target = camera.transform.position + Vector3.up * blockConfig.InitialSize.y;
            StartCoroutine(CameraMove(target));
        }

        private void OnGameRestarting()
        {
            StartCoroutine(CameraMove(worldConfig.CameraStartPosition));
        }

        private void GameStarting()
        {
           
        }
    }
}

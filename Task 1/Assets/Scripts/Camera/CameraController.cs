using System.Collections;
using UnityEngine;

namespace StackApp.CameraController
{
    public class CameraController : MonoBehaviour
    {
        private Camera playerCamera;
        private GameConfigurationDataWorld worldConfig;
        private GameConfigurationDataBlock blockConfig;
       
        public void Initialization(GameConfigurationDataWorld worldConfiguration, GameConfigurationDataBlock blockConfiguration)
        {
            worldConfig = worldConfiguration;
            blockConfig = blockConfiguration;

            playerCamera = Camera.main;
            playerCamera.transform.position = worldConfig.CameraStartPosition;
            playerCamera.transform.rotation = Quaternion.Euler(worldConfig.CameraStartRotation);

            EventController.OnGameRestarting += OnGameRestarting;
            EventController.OnBlockRightPlacing += OnBlockRightPlacing;
        }

        private IEnumerator CameraMove(Vector3 target, float speed)
        {
            while (Vector3.Distance(playerCamera.transform.position, target) > float.Epsilon)
            {
                playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
        }

        private void OnBlockRightPlacing()
        {
            var target = playerCamera.transform.position + Vector3.up * blockConfig.InitialSize.y;
            StartCoroutine(CameraMove(target, worldConfig.CameraSpeed));
        }

        private void OnGameRestarting()
        {
            StartCoroutine(CameraMove(worldConfig.CameraStartPosition, worldConfig.CameraRestartingSpeed));
        }

        private void OnDestroy()
        {
            EventController.OnGameRestarting -= OnGameRestarting;
            EventController.OnBlockRightPlacing -= OnBlockRightPlacing;
        }
    }
}

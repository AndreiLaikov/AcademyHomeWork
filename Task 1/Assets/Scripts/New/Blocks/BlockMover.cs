using UnityEngine;

namespace StackApp.Blocks
{
    public class BlockMover : MonoBehaviour
    {
        public float Speed;
        public float Amplitude;
        private Vector3 startPosition;
        private float time;

        private void Start()
        {
            startPosition = transform.position - transform.right * (Amplitude / 2);
        }

        private void Update()
        {
            PingPongMove();
        }

        private void PingPongMove()
        {
            time += Time.deltaTime;
            var targetPosX = Mathf.PingPong(Speed * time, Amplitude);
            transform.position = new Vector3(targetPosX + startPosition.x, startPosition.y, startPosition.z);
        }
    }
}
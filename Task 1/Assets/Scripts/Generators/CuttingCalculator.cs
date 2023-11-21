using UnityEngine;

namespace StackApp.Generators
{
    public static class CuttingCalculator
    {
        public struct MeshesData
        {
            public Vector3 PlayablePosition;
            public Vector3 FallingPosition;
            public Vector3 PlayableSize;
            public Vector3 FallingSize;
        }

        public static MeshesData Calculate(Transform playableBlock, Transform movingBlock, Vector3 currentBlockSize)
        {
            MeshesData data = new MeshesData();
            var deltaX = movingBlock.transform.position.x - playableBlock.transform.position.x;
            var sign = Mathf.Sign(deltaX);
            var halfDeltaX = deltaX / 2;
            var absDeltaX = Mathf.Abs(deltaX);

            var playablePivot = playableBlock.position.x + halfDeltaX;
            var fallingPivot = playablePivot + sign * currentBlockSize.x / 2;

            data.PlayablePosition = new Vector3(playablePivot, movingBlock.position.y, movingBlock.position.z);
            data.FallingPosition = new Vector3(fallingPivot, movingBlock.position.y, movingBlock.position.z);

            data.PlayableSize = new Vector3(currentBlockSize.x - absDeltaX, currentBlockSize.y, currentBlockSize.z);
            data.FallingSize = new Vector3(absDeltaX, currentBlockSize.y, currentBlockSize.z);

            return data;
        }
    }
}

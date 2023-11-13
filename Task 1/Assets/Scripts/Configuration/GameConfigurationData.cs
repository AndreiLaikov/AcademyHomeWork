using System;
using UnityEngine;
using StackApp.Blocks;

namespace StackApp
{
    [Serializable]
    public class GameConfigurationData
    {
        public GameConfigurationDataBlock BlockConfiguration;
        public GameConfigurationDataMover MoverConfiguration;
        public GameConfigurationDataWorld WorldConfiguration;
    }

    [Serializable]
    public class GameConfigurationDataBlock
    {
        public Block BlockPrefab; //Prefab with component Block and meshRenderer, meshFilter, BoxCollider
        public Transform BlocksParentTransform; //Place for all blocks
        public Vector3 InitialSize; //Initial blocks size
        public Vector3 InitialPosition; //Initial bloks position
        public Vector3 StartingBoxPosition; //Initial position for starting box
        public Color initialColor; //Initial blocks color
    }

    [Serializable]
    public class GameConfigurationDataMover
    {
        public float MovingAmplitude; //Amplitude moving for PingPong Move
        public float Speed; //Moving speed
    }

    [Serializable]
    public class GameConfigurationDataWorld
    {
        public Vector3 CameraStartPosition; //Initial Camera position
        public Vector3 CameraStartRotation; //Initial Camera rotation
        public float CameraSpeed; //Camera speed for move between blocks
        public float CameraRestartingSpeed; //Camera speed for return to start position
    }
}
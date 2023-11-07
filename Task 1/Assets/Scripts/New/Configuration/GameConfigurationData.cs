using System;
using UnityEngine;
using StackApp.Block;

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
        public Vector3 InitialSize;
        public Vector3 InitialPosition;
        public BlockElement blockPrefab;
    }

    [Serializable]
    public class GameConfigurationDataMover
    {
        public float MovingDistance; 
        public float Speed;
    }

    [Serializable]
    public class GameConfigurationDataWorld
    {
        public Vector3 StartingBoxPosition;
        public Vector3 CameraStartPosition;
        public Transform WorldParentTransform;
    }
}
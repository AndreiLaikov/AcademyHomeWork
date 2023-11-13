using System;
using UnityEngine;
using StackApp.Tower;

namespace StackApp.Player
{
    public class Player : MonoBehaviour
    {
        public int CurrentScore;
        public int HighScore;
        private TowerCreator currentTower;
       
        public void Initialize(TowerCreator tower)
        {
            currentTower = tower;
            CurrentScore = currentTower.PlayableBlocksCount;
        }

        public void AddScore()
        {
            CurrentScore = currentTower.PlayableBlocksCount;
            HighScore = Math.Max(HighScore, CurrentScore);
        }
    }
}

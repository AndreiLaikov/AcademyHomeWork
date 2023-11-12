using System;

namespace StackApp.Player
{
    public class Player
    {
        public int CurrentScore;
        public int HighScore;
        private BlocksController blocksController;

        public void Initialize(BlocksController controller)
        {
            blocksController = controller;
        }

        private void AddScore()
        {
            CurrentScore = blocksController.PlayableBlocksCount;
            HighScore = Math.Max(HighScore, CurrentScore);
        }
    }
}

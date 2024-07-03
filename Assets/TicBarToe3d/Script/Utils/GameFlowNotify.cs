using System.Collections.Generic;

namespace TicBarToe3d
{
    public class GameFlowNotify
    {
        private List<IGameFlow> observers = new List<IGameFlow>();
        public void Attach(IGameFlow gameflow)
        {
            observers.Add(gameflow);
        }
        public void Detach(IGameFlow gameflow)
        {
            observers.Remove(gameflow);
        }
        
        public void NotifyRoundIntro()
        {
            foreach (var gameflow in observers)
            {
                gameflow.OnRoundIntro();
            }
        }
        public void NotifyRoundPlay()
        {
            foreach (var gameflow in observers)
            {
                gameflow.OnRoundPlay();
            }
        }
        public void NotifyEndRound()
        {
            foreach (var gameflow in observers)
            {
                gameflow.OnEndRound();
            }
        }
        public void NotifyEndGame()
        {
            foreach (var gameflow in observers)
            {
                gameflow.OnEndGame();
            }
        }
    }
}


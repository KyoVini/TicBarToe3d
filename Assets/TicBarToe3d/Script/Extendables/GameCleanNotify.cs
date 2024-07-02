using System.Collections.Generic;
namespace TicBarToe3d
{
    public class GameCleanNotify 
    {
        private List<IGameClean> gameclean = new List<IGameClean>();
        public void Attach(IGameClean objclean)
        {
            gameclean.Add(objclean);
        }
        public void Detach(IGameClean objclean)
        {
            gameclean.Remove(objclean);
        }
        public void NotifyClean()
        {
            foreach (var gameflow in gameclean)
            {
                gameflow.OnCleanGame();
            }
        }

    }
}
    

using System.Collections.Generic;
namespace TicBarToe3d
{
    public class GameRestartNotify 
    {
        private List<IGameRestart> gamerestart = new List<IGameRestart>();

        public void Attach(IGameRestart _gamerestart)
        {
            gamerestart.Add(_gamerestart);
        }
        public void Detach(IGameRestart _gamerestart)
        {
            gamerestart.Remove(_gamerestart);
        }
        public void NotifyGameRestart()
        {
            foreach(var _gamerestart in gamerestart)
            {
                _gamerestart.OnRestarGame();
            }
        }
    }

}

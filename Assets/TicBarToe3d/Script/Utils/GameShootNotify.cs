using System.Collections.Generic;
namespace TicBarToe3d
{
    public class GameShootNotify
    {
        private List<IGameShoot> gameshoot = new List<IGameShoot>();

        public void Attach(IGameShoot _gameshoot)
        {
            gameshoot.Add(_gameshoot);
        }
        public void Detach(IGameShoot _gameshoot)
        {
            gameshoot.Remove(_gameshoot);
        }
        public void NotifyGameShoot()
        {
            foreach (var _gameshoot in gameshoot)
            {
                _gameshoot.OnShoot();
            }
        }
    }
}
    

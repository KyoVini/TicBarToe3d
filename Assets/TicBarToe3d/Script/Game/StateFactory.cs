namespace TicBarToe3d
{
    public class StateFactory
    {
        private StateRoundIntro roundintro;
        private StateRoundPlay roundplay;
        private StateShoot gameshoot;
        private StateEndRound gameendround;
        private StateEndGame gameendgame;
        private StateRestart gamerestart;
        private StateGameClean gameclean;
        public StateFactory()
        {
            roundintro = new StateRoundIntro();
            roundplay = new StateRoundPlay();
            gameshoot = new StateShoot();
            gameendround = new StateEndRound();
            gameendgame = new StateEndGame();
            gameclean = new StateGameClean();
            gamerestart = new StateRestart();
        }
    }
}

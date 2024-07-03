using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class GameDartManager : Singleton<GameDartManager>
    {
        private GameFlowNotify gamestats = new GameFlowNotify();
        private GameCleanNotify gameclean = new GameCleanNotify();
        private GameRestartNotify gamerestart = new GameRestartNotify();
        private GameShootNotify gameshoot = new GameShootNotify();
        public void Start()
        {
            IntroGame();
        }
        public GameFlowNotify GetGameStats() => gamestats;
        public GameCleanNotify GetGameClean() =>  gameclean; 
        public GameRestartNotify GetGameRestart() => gamerestart;
        public GameShootNotify GetShoot() => gameshoot;
        public void IntroGame()
        {
            Invoke(nameof(RoundIntro), 0.1f);
            //cam will fly around the scene and end in the player vision position
        }
        public void RoundIntro()
        {
            gamestats.NotifyRoundIntro();
            Invoke(nameof(RoundPlay), 1.0f);
        }
        public void RoundPlay()
        {
            gamestats.NotifyRoundPlay();
        }
        public void Shoot()
        {
            gameshoot.NotifyGameShoot();
        }
        public void EndRound()
        {
            gamestats.NotifyEndRound();
            RoundIntro();
        }

        public void EndGame()
        {
            gamestats.NotifyEndGame();
            gameclean.NotifyClean();
        }
        public void RestartGame()
        {
            gamerestart.NotifyGameRestart();
            RoundIntro();
        }
    }
}


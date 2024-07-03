using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class GameDartManager : Singleton<GameDartManager>
    {
        private GameFlowNotify gamestats = new GameFlowNotify();
        private GameCleanNotify gameclean = new GameCleanNotify();
        private GameRestartNotify gamerestart = new GameRestartNotify();
        public void Start()
        {
            IntroGame();
        }
        public GameFlowNotify GetGameStats(){ return gamestats;}
        public GameCleanNotify GetGameClean() { return gameclean; }
        public GameRestartNotify GetGameRestart() { return gamerestart; }
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


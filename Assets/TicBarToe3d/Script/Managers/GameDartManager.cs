using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class GameDartManager : Singleton<GameDartManager>
    {
        private Notifier gameintro = new Notifier();
        private Notifier roundintro = new Notifier();
        private Notifier roundplay = new Notifier();
        private Notifier gameshoot = new Notifier();
        private Notifier roundend = new Notifier();
        private Notifier gameend = new Notifier();
        private Notifier gameclean = new Notifier();
        private Notifier gamerestart = new Notifier();
        public void Start() { Invoke(nameof(RoundIntro), 0.1f); }
        public Notifier GetGameIntro() => gameintro;
        public Notifier GetRoundIntro() => roundintro;
        public Notifier GetRoundPlay() => roundplay;
        public Notifier GetGameShoot() => gameshoot;
        public Notifier GetRoundEnd() => roundend;
        public Notifier GetGameEnd() => gameend;
        public Notifier GetGameClean() =>  gameclean; 
        public Notifier GetGameRestart() => gamerestart;
        
        public void IntroGame()
        {
            RoundIntro();
            //cam will fly around the scene and end in the player vision position
        }
        public void RoundIntro()
        {
            roundintro.Notify();
            Invoke(nameof(RoundPlay), 1.0f);
        }
        public void RoundPlay()
        {
            roundplay.Notify();
        }
        public void Shoot()
        {
            gameshoot.Notify();
        }
        public void EndRound()
        {
            roundend.Notify();
            RoundIntro();
        }

        public void EndGame()
        {
            gameend.Notify();
            gameclean.Notify();
        }
        public void RestartGame()
        {
            gamerestart.Notify();
            RoundIntro();
        }
    }
}


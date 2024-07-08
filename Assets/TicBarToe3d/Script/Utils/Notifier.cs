using System.Collections.Generic;
using UnityEngine;

namespace TicBarToe3d
{
    public class Notifier : IListener
    {
        private List<INotifier> mylistener { get; set; } 

        public void Attach(INotifier _listener)
        {
            if(mylistener == null)
            {
                mylistener = new List<INotifier>();
            }
            mylistener.Add(_listener);
        }
        public void Detach(INotifier _listener)
        {
            mylistener.Remove(_listener);
        }

        public void Notify()
        {
            foreach (var _gamestats in mylistener)
            {
                _gamestats?.OnNotify();
            }
        }

    }

}

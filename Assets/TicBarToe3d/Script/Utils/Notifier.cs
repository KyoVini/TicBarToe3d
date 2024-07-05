using System.Collections.Generic;
namespace TicBarToe3d
{
    public class Notifier : IListener
    {
        private List<INotifier> mylistener { get; set; } 

        public void Attach(INotifier _listener)
        {
            mylistener.Add(_listener);
        }
        public void Detach(INotifier _listener)
        {
            mylistener.Remove(_listener);
        }

        public void Notify()
        {
            foreach (var _gamerestart in mylistener)
            {
                _gamerestart.OnNotify();
            }
        }

    }

}

namespace TicBarToe3d
{
    public interface IListener
    {
        void Attach(INotifier _listener);
        void Detach(INotifier _listener);
        void Notify();
    }
}

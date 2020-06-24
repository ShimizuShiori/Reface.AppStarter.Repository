namespace Reface.AppStarter.Repository
{
    public interface ITransactionListener
    {
        void Listen(ITransactionNotifier notifier);
    }
}

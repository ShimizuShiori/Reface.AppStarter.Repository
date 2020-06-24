namespace Reface.AppStarter.Repository
{
    public interface IDatabaseTransactionController
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}

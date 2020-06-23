namespace Reface.AppStarter.Repository
{
    public interface ITranscationManager
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}

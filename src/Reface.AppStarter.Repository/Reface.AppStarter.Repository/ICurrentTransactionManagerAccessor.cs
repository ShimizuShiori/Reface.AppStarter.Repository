using System.Data;

namespace Reface.AppStarter.Repository
{
    public interface ICurrentTransactionManagerAccessor
    {
        ITranscationManager Get();
    }
}

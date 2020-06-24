using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Repository
{
    [Component]
    public class DefaultCurrentTransactionManagerAccessor : ICurrentTransactionManagerAccessor
    {
        private readonly IWork work;
        public DefaultCurrentTransactionManagerAccessor(IWork work)
        {
            this.work = work;
        }

        public ITranscationManager Get()
        {
            return work.Context.GetOrCreate("CURRENT_TRANSACTION_MANAGER", key => work.CreateComponent<ITranscationManager>());
        }
    }
}

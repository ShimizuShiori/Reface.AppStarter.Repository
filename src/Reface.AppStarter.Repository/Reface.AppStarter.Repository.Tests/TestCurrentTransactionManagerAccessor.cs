using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Repository.Tests
{
    [Component]
    public class TestCurrentTransactionManagerAccessor : ICurrentTransactionManagerAccessor
    {
        private readonly IWork work;

        public TestCurrentTransactionManagerAccessor(IWork work)
        {
            this.work = work;
        }

        public ITranscationManager Get()
        {
            return work.Context.GetOrCreate("CURRENT_TRANSACTION_MANAGER", key =>
            {
                return new TestTransactionManager();
            });
        }
    }
}

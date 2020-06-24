using Reface.AppStarter.Attributes;
using System.Collections.Generic;

namespace Reface.AppStarter.Repository
{
    [Component]
    public class DefaultTransactionManager : ITranscationManager
    {
        private readonly ITransactionCounter counter;

        public DefaultTransactionManager(ITransactionCounter counter, IEnumerable<ITransactionListener> listeners)
        {
            this.counter = counter;
            listeners.ForEach(l => l.Listen(counter));
        }

        public void Begin()
        {
            this.counter.CountBegin();
        }

        public void Commit()
        {
            this.counter.CountCommit();
        }

        public void Rollback()
        {
            this.counter.CountRollback();
        }
    }
}

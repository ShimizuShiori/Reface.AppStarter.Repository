using Reface.AppStarter.Attributes;
using System;

namespace Reface.AppStarter.Repository
{
    [Component]
    public class DefaultTransactionListener : ITransactionListener
    {
        private readonly IDatabaseTransactionController controller;

        public DefaultTransactionListener(IWork work)
        {
            IDatabaseTransactionController _controller;
            if (work.TryCreateComponent<IDatabaseTransactionController>(out _controller))
                this.controller = _controller;
        }

        public void Listen(ITransactionNotifier notifier)
        {
            if (this.controller == null) 
                return;

            notifier.StartBegin += Notifier_StartBegin;
            notifier.StartCommit += Notifier_StartCommit;
            notifier.StartRollback += Notifier_StartRollback;
        }

        private void Notifier_StartRollback(object sender, EventArgs e)
        {
            this.controller.Rollback();
        }

        private void Notifier_StartCommit(object sender, EventArgs e)
        {
            this.controller.Commit();
        }

        private void Notifier_StartBegin(object sender, EventArgs e)
        {
            this.controller.Begin();
        }
    }
}

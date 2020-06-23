using Reface.AppStarter.Attributes;
using Reface.AppStarter.ComponentLifetimeListeners;
using Reface.AppStarter.Proxy;
using System;

namespace Reface.AppStarter.Repository.Proxies
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TranscationAttribute : ProxyAttribute, IOnPropertiesInjected
    {
        public ICurrentTransactionManagerAccessor CurrentTranscationAccessor { get; set; }
        public ITranscationCounter TranscationCounter { get; set; }

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
            this.TranscationCounter.CountBegin();
        }
        public override void OnExecuted(ExecutedInfo executedInfo)
        {
            this.TranscationCounter.CountCommit();
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
            this.TranscationCounter.CountRollback();
        }

        public void OnPropertiesInjected()
        {
            this.TranscationCounter.StartBegin += TranscationCounter_StartBegin;
            this.TranscationCounter.StartRollback += TranscationCounter_StartRollback;
            this.TranscationCounter.StartCommit += TranscationCounter_StartCommit;
        }

        private void TranscationCounter_StartCommit(object sender, EventArgs e)
        {
            if (this.CurrentTranscationAccessor == null) return;
            this.CurrentTranscationAccessor.Get().Commit();
        }

        private void TranscationCounter_StartRollback(object sender, EventArgs e)
        {
            if (this.CurrentTranscationAccessor == null) return;
            this.CurrentTranscationAccessor.Get().Rollback();
        }

        private void TranscationCounter_StartBegin(object sender, EventArgs e)
        {
            if (this.CurrentTranscationAccessor == null) return;
            this.CurrentTranscationAccessor.Get().Begin();
        }
    }
}

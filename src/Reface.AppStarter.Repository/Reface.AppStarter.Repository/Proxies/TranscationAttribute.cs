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

        private ITranscationManager tm;

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
            tm.Begin();
        }
        public override void OnExecuted(ExecutedInfo executedInfo)
        {
            tm.Commit();
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
            tm.Rollback();
        }

        public void OnPropertiesInjected()
        {
            this.tm = this.CurrentTranscationAccessor.Get();
        }
    }
}

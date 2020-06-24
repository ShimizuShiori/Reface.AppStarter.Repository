//using Reface.AppStarter.Attributes;
//using System.Diagnostics;

//namespace Reface.AppStarter.Repository.Tests.Listeners
//{
//    [Component]
//    public class TranChangedOutput : ITransactionListener
//    {
//        public void Listen(ITransactionNotifier notifier)
//        {
//            notifier.StartBegin += (sender, e) => Debug.WriteLine("BeginTran");
//            notifier.StartCommit += (sender, e) => Debug.WriteLine("CommitTran");
//            notifier.StartRollback += (sender, e) => Debug.WriteLine("RollbackTran");
//        }
//    }
//}

using System;

namespace Reface.AppStarter.Repository
{
    public interface ITransactionNotifier
    {
        /// <summary>
        /// 当认为此时应当开启事务时的事件
        /// </summary>
        event EventHandler StartBegin;

        /// <summary>
        /// 当认为此时应当提交事务时的事件
        /// </summary>
        event EventHandler StartCommit;

        /// <summary>
        /// 当认为此时应当回滚事务时的事件
        /// </summary>
        event EventHandler StartRollback;
    }
}

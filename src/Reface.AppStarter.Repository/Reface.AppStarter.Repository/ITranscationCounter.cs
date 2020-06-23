using System;

namespace Reface.AppStarter.Repository
{
    /// <summary>
    /// 事务计算器，由切面产生的事务往往容易产生各种形式的嵌套。
    /// 事务计算器可以根据一定的规则判断哪次真正的打开事务，哪次真正提交和回滚事务。
    /// 默认的实现是：
    /// 当提交请求数与打开请求数相同时，提交事务。<br />
    /// 当回滚事务时，立即回滚。
    /// </summary>
    public interface ITranscationCounter
    {
        /// <summary>
        /// 计数开启事务
        /// </summary>
        void CountBegin();

        /// <summary>
        /// 计数提交事务
        /// </summary>
        void CountCommit();

        /// <summary>
        /// 计数回滚事务
        /// </summary>
        void CountRollback();

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

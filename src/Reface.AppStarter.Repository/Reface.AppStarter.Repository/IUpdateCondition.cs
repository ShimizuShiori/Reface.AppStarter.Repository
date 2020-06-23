using System;
using System.Linq.Expressions;

namespace Reface.AppStarter.Repository
{
    /// <summary>
    /// Update 的条件
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUpdateCondition<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="where"></param>
        void Where(Expression<Func<TEntity, bool>> where);

    }
}

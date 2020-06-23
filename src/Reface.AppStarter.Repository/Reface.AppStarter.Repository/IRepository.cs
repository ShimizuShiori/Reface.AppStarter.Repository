using System;
using System.Linq.Expressions;

namespace Reface.AppStarter.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class, new()
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        IUpdateCondition<TEntity> Update(Expression<Func<TEntity, TEntity>> set);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        void Clear();
        ISelector<TEntity> Select();

        int Count(Expression<Func<TEntity, bool>> condition);
    }
}

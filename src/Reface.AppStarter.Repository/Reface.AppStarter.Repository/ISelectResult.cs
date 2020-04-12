using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Reface.AppStarter.Repository
{
    public interface ISelectResult<TEntity>
            where TEntity : class
    {
        ISelectResult<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        ISelectResult<TEntity> OrderByAsc(Expression<Func<TEntity, object>> expression);
        ISelectResult<TEntity> OrderByDesc(Expression<Func<TEntity, object>> expression);
        IEnumerable<TEntity> ToList();

        IEnumerable<TEntity> ToPageList(int pageIndex, int pageSize);

        IEnumerable<TEntity> ToPageList(int pageIndex, int pageSize, out int count);
        TEntity First();
        TEntity FirstOrNull();
        int Count();
    }
}

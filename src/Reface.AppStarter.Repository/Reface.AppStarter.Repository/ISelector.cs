using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Reface.AppStarter.Repository
{
    /// <summary>
    /// 查询器接口，可以进行复杂的查询。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISelector<TEntity>
            where TEntity : class
    {
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        ISelector<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        ISelector<TEntity> OrderByAsc(Expression<Func<TEntity, object>> expression);
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        ISelector<TEntity> OrderByDesc(Expression<Func<TEntity, object>> expression);
        /// <summary>
        /// 查询出结果
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> ToList();
        /// <summary>
        /// 分页查询出结果
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<TEntity> ToPageList(int pageIndex, int pageSize);
        /// <summary>
        /// 分页查询出结果，并返回总数据行数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<TEntity> ToPageList(int pageIndex, int pageSize, out int count);

        /// <summary>
        /// 获取第一个数据
        /// </summary>
        /// <returns></returns>
        TEntity First();

        /// <summary>
        /// 获取第一个数据，若不存在则返回 null
        /// </summary>
        /// <returns></returns>
        TEntity FirstOrNull();

        /// <summary>
        /// 返回条件要求的数据行数
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}

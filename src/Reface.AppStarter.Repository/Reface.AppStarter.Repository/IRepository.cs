namespace Reface.AppStarter.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class, new()
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Clear();
        ISelectResult<TEntity> Select();
    }
}

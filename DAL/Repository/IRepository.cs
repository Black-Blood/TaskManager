namespace DAL.Repository;

internal interface IRepository<TEntity> where TEntity : class
{
    public IEnumerable<TEntity> Read();

    public void Create(TEntity item);

    public void Update(TEntity item);

    public void Delete(TEntity item);
}

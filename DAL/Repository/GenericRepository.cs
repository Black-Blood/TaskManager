using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private DbContext _context;
    private DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public void Create(TEntity item)
    {
        _dbSet.Add(item);
    }

    public void Delete(TEntity item)
    {
        _dbSet.Remove(item);
    }

    public void Update(TEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public IEnumerable<TEntity> Read()
    {
        return _dbSet.AsNoTracking().ToList();
    }
}
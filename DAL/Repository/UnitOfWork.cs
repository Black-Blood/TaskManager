using DAL.Model;


namespace DAL.Repository;

public class UnitOfWork : IDisposable
{
    private bool _disposed = false;
    private ApplicationDbContext _context = new();

    public GenericRepository<Project> ProjectRepository { get; private set; } 

    public GenericRepository<Assignment> AssignmentRepository { get; private set; }

    public UnitOfWork()
    {
        ProjectRepository = new(_context);
        AssignmentRepository = new(_context);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
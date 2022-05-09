using DAL.Model;


namespace DAL.Repository;

public class UnitOfWork : IDisposable
{
    private readonly ApplicationDbContext _context = new();
    private bool _disposed = false;

    public Repository<Project> ProjectRepository { get; private set; } 

    public Repository<Assignment> AssignmentRepository { get; private set; }

    public UnitOfWork()
    {
        ProjectRepository = new(_context);
        AssignmentRepository = new(_context);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();

        _disposed = true;
    }
}
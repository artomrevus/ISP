using System.Collections;
using ISP.DAL.Data;
using ISP.DAL.Interfaces;
using ISP.DAL.Repositories;

namespace ISP.DAL;

public class UnitOfWork(IspDbContext context) : IUnitOfWork
{
    private Hashtable? _repositories;
    private bool _disposed;

    public IGenericRepository<T> Repository<T>() where T : class
    {
        _repositories ??= new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);

            _repositories.Add(type, repositoryInstance);
        }
        
        return (IGenericRepository<T>)_repositories[type]!;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
namespace ISP.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    
    Task<int> SaveChangesAsync();
}
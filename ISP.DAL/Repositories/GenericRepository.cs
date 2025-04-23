using System.Linq.Expressions;
using ISP.DAL.Data;
using ISP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repositories;

public class GenericRepository<T>(IspDbContext context) : IGenericRepository<T>
    where T : class, IEntity
{
    protected readonly IspDbContext Context = context;
    protected readonly DbSet<T> DbSet = context.Set<T>();

    public virtual async Task<IEnumerable<T>> GetAsync(
        int? skip = null,
        int? take = null,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> query = DbSet;

        if (filter is not null) query = query.Where(filter);

        if (orderBy is not null) query = orderBy(query);

        if (skip.HasValue) query = query.Skip(skip.Value);

        if (take.HasValue) query = query.Take(take.Value);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = DbSet;

        if (filter is not null) query = query.Where(filter);
        
        return await query.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual Task UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public virtual Task DeleteAsync(T entity)
    {
        if (Context.Entry(entity).State == EntityState.Detached) DbSet.Attach(entity);

        DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = DbSet;

        if (filter is not null) query = query.Where(filter);

        return await query.AsNoTracking().CountAsync();
    }
}
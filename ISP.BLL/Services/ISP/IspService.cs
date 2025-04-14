using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.Exceptions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class IspService<TEntity, TGetDto, TAddDto, TUpdateDto, TFilter>(IUnitOfWork unitOfWork, IMapper mapper)
    : IIspService<TGetDto, TAddDto, TUpdateDto, TFilter>
    where TEntity : class, IEntity
{
    private IGenericRepository<TEntity> Repository => unitOfWork.Repository<TEntity>();
    private IMapper Mapper => mapper;
    
    public virtual async Task<IEnumerable<TGetDto>> GetAllAsync(PaginationParameters pagination, TFilter filter, SortingParameters sorting)
    {
        var skipRecords = (pagination.PageNumber - 1) * pagination.PageSize;
        var takeRecords = pagination.PageSize;
        
        var filterExpression = BuildFilter(filter);
        var sortingFunc = BuildSorting(sorting);

        var entities = await Repository.GetAsync(
            skipRecords, 
            takeRecords,
            filterExpression,
            sortingFunc);
        
        return Mapper.Map<IEnumerable<TGetDto>>(entities);
    }

    public virtual async Task<TGetDto> GetByIdAsync(int id)
    {
        var entity = await Repository.GetByIdAsync(id);

        if (entity is null)
        {
            throw new NotFoundException($"Entity with id '{id}' not found.");
        }

        return Mapper.Map<TGetDto>(entity);
    }

    public virtual async  Task<TGetDto> AddAsync(TAddDto dto)
    {
        var entity = Mapper.Map<TEntity>(dto);
        entity.CreateDateTime = DateTime.Now;
        
        await Repository.AddAsync(entity);
        await unitOfWork.SaveChangesAsync();
            
        return Mapper.Map<TGetDto>(entity);
    }

    public virtual async Task<TGetDto> UpdateAsync(int id, TUpdateDto dto)
    {
        var entityToUpdate = await Repository.GetByIdAsync(id);
            
        if (entityToUpdate is null)
        {
            throw new NotFoundException($"Entity with id '{id}' not found.");
        }
        
        var updatedEntity = Mapper.Map<TEntity>(dto);
        updatedEntity.CreateDateTime = entityToUpdate.CreateDateTime;
        updatedEntity.UpdateDateTime = DateTime.Now;
            
        await Repository.UpdateAsync(updatedEntity);
        await unitOfWork.SaveChangesAsync();
            
        return Mapper.Map<TGetDto>(updatedEntity);
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entityToDelete = await Repository.GetByIdAsync(id);
        
        if (entityToDelete is null)
        {
            throw new NotFoundException($"Entity with id '{id}' not found.");
        }
        
        await Repository.DeleteAsync(entityToDelete);
        await unitOfWork.SaveChangesAsync();
    }

    public virtual async Task<int> GetCountAsync(TFilter filter)
    {
        var filterExpression = BuildFilter(filter);
        return await Repository.CountAsync(filterExpression);
    }

    protected virtual Expression<Func<TEntity, bool>>? BuildFilter(TFilter filterParameters)
    {
        return null;
    }

    protected virtual Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? BuildSorting(SortingParameters sortingParameters)
    {
        return null;
    }
}
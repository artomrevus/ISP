using System.Linq.Expressions;
using ISP.DAL.Entities;
using MongoDB.Driver;

namespace ISP.DAL.Interfaces;

public interface IUserActivityRepository
{
    Task<IEnumerable<UserActivity>> GetAsync(
        int? skip = null,
        int? take = null,
        FilterDefinition<UserActivity>? filter = null,
        SortDefinition<UserActivity>? sortBy = null);
    
    Task AddAsync(UserActivity activity);

    Task<long> CountAsync(FilterDefinition<UserActivity>? filter = null);
}
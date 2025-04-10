using ISP.DAL.Data;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;
using MongoDB.Driver;

namespace ISP.DAL.Repositories;

public class UserActivityRepository(MongoDbContext mongoContext) : IUserActivityRepository
{
    public async Task<IEnumerable<UserActivity>> GetAsync(
        int? skip = null,
        int? take = null, 
        FilterDefinition<UserActivity>? filter = null, 
        SortDefinition<UserActivity>? sortBy = null)
    {
        filter ??= Builders<UserActivity>.Filter.Empty;
        sortBy ??= Builders<UserActivity>.Sort.Ascending(a => a.Timestamp);
        
        return await mongoContext.UserActivities
            .Find(filter)
            .Sort(sortBy)
            .Skip(skip)
            .Limit(take)
            .ToListAsync();
    }

    public async Task AddAsync(UserActivity activity)
    {
        await mongoContext.UserActivities.InsertOneAsync(activity);
    }
    
    public virtual async Task<long> CountAsync(FilterDefinition<UserActivity>? filter = null)
    {
        filter ??= Builders<UserActivity>.Filter.Empty;

        return await mongoContext.UserActivities
            .Find(filter)
            .CountDocumentsAsync();
    }
}
using ISP.DAL.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ISP.DAL.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("Monitoring_Db"));
        _database = client.GetDatabase("IspMonitoring");
    }

    public IMongoCollection<UserActivity> UserActivities => _database.GetCollection<UserActivity>("UserActivities");
}
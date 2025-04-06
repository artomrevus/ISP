using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ISP.DAL.Entities;

public class UserActivity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
        
    public int? EmployeeId { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    public string TableName { get; set; }
    public string Action { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string Details { get; set; }
}
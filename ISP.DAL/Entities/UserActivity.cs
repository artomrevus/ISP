using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ISP.DAL.Entities;

public class UserActivity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
        
    public string UserId { get; set; }
    public string? EmployeeId { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    public string ActionOn { get; set; }
    public string Action { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Details { get; set; }
}
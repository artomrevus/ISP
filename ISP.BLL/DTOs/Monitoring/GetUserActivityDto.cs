namespace ISP.BLL.DTOs.Monitoring;

public class GetUserActivityDto
{
    public string UserId { get; set; }
    
    public string? EmployeeId { get; set; }
    
    public string UserName { get; set; }
    
    public string Role { get; set; }
    
    public string ActionOn { get; set; }
    
    public string Action { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public string Details { get; set; }
}
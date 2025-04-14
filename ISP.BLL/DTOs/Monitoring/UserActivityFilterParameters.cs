namespace ISP.BLL.DTOs.Monitoring;

public class UserActivityFilterParameters
{
    public int? EmployeeId { get; set; }
    
    public int? EmployeeOfficeId { get; set; }
    
    public DateTime? StartDateTime { get; set; }
    
    public DateTime? EndDateTime { get; set; }
    
    public string? UserNameContains { get; set; }
    
    public string? RoleContains { get; set; }
    
    public string? ActionOnContains { get; set; }
    
    public string? ActionContains { get; set; }
}
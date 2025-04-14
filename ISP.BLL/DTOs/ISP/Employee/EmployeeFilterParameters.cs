namespace ISP.BLL.DTOs.ISP.Employee;

public class EmployeeFilterParameters
{
    public int? EmployeePositionId { get; set; }

    public int? EmployeeStatusId { get; set; }
    
    public int? OfficeId { get; set; }
    
    public int? CityId { get; set; }
    
    public string? EmployeePositionContains { get; set; }

    public string? EmployeeStatusContains { get; set; }
    
    public string? CityContains { get; set; }
}
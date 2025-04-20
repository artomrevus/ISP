namespace ISP.BLL.DTOs.ISP.Employee;

public class EmployeeFilterParameters
{
    public List<int> EmployeePositionIds { get; set; } = [];

    public List<int> EmployeeStatusIds { get; set; } = [];
    
    public List<int> OfficeIds { get; set; } = [];
    
    public List<int> CityIds { get; set; } = [];
}
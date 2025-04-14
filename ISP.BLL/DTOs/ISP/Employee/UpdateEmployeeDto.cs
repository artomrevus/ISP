namespace ISP.BLL.DTOs.ISP.Employee;

public class UpdateEmployeeDto
{
    public int Id { get; set; }

    public int EmployeePositionId { get; set; }

    public int EmployeeStatusId { get; set; }

    public int OfficeId { get; set; }
}
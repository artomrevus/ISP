namespace ISP.BLL.DTOs.ISP.EmployeeStatus;

public class UpdateEmployeeStatusDto
{
    public int Id { get; set; }

    public string EmployeeStatusName { get; set; } = default!;
}
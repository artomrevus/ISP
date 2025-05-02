namespace ISP.BLL.DTOs.Auth;

public class RegisterEmployeeRequestDto
{
    public string UserName { get; set; } = default!;
    
    public string Password { get; set; } = default!;
    
    public int EmployeeId { get; set; }
}
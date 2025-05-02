namespace ISP.BLL.DTOs.Auth;

public class RegisterEmployeeResponseDto
{
    public string UserId { get; set; } = default!;
    
    public string EmployeeId { get; set; }  = default!;
    
    public string UserName { get; set; } = default!;
    
    public string Role { get; set; } = default!;
}
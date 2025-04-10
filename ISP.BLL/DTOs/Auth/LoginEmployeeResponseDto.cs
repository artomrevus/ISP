namespace ISP.BLL.DTOs.Auth;

public class LoginEmployeeResponseDto
{
    public string UserId { get; set; } = default!;
    
    public string EmployeeId { get; set; }  = default!;
    
    public string UserName { get; set; } = default!;
    
    public string Token { get; set; } = default!;
    
    public string Role { get; set; } = default!;
}
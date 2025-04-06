namespace ISP.BLL.DTOs.Auth;

public class LoginAdminResponseDto
{
    public string UserName { get; set; } = default!;
    public string Token { get; set; } = default!;
    public string Role { get; set; } = default!;
}
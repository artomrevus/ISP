using AutoMapper;
using ISP.BLL.DTOs.Auth;
using ISP.BLL.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ISP.BLL.Services.Auth;

public class UserAccountsService(
    UserManager<IdentityUser> userManager,
    IMapper mapper)
    : IUserAccountsService
{
    public async Task<IEnumerable<UserAccountDto>> GetAllAsync()
    {
        var users = await userManager.Users.ToListAsync();
        return mapper.Map<IEnumerable<UserAccountDto>>(users);
    }
}
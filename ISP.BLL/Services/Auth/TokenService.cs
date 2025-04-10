using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ISP.BLL.Constants;
using ISP.BLL.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ISP.BLL.Services.Auth;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string CreateJwtToken(IdentityUser user, string role)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName ?? throw new InvalidOperationException("Identity user username is null")),
            new (ClaimTypes.Role, role),
            new (IspAuthClaims.UserId, user.Id),
        };

        return CreateJwtToken(claims);
    }
    
    public string CreateJwtToken(IdentityUser user, string role, string employeeId)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName ?? throw new InvalidOperationException("Identity user username is null")),
            new (IspAuthClaims.EmployeeId, employeeId),
            new (ClaimTypes.Role, role),
            new (IspAuthClaims.UserId, user.Id),
        };
        
        return CreateJwtToken(claims);
    }

    private string CreateJwtToken(List<Claim> claims)
    {
        // Credentials:
        var configurationJwtKey = configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(configurationJwtKey))
        {
            throw new InvalidOperationException("Jwt:Key is not configured.");
        }
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationJwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Token:
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: credentials);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
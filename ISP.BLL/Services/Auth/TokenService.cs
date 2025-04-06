using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
            new ("id", user.Id),
            new (ClaimTypes.Role, role ?? throw new InvalidOperationException("Identity user role is null"))
        };

        return CreateJwtToken(user, claims);
    }
    
    public string CreateJwtToken(IdentityUser user, string role, int employeeId)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName ?? throw new InvalidOperationException("Identity user username is null")),
            new ("id", user.Id),
            new ("employeeId", employeeId.ToString()),
            new (ClaimTypes.Role, role ?? throw new InvalidOperationException("Identity user role is null"))
        };
        
        return CreateJwtToken(user, claims);
    }

    private string CreateJwtToken(IdentityUser user, List<Claim> claims)
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
using System.Text;
using ISP.API.ModelBinders;
using ISP.BLL.Interfaces;
using ISP.BLL.Interfaces.Auth;
using ISP.BLL.Interfaces.ISP;
using ISP.BLL.Interfaces.Monitoring;
using ISP.BLL.Services;
using ISP.BLL.Services.Auth;
using ISP.BLL.Services.ISP;
using ISP.BLL.Services.Monitoring;
using ISP.DAL;
using ISP.DAL.Data;
using ISP.DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ISP.API.Extensions;

public static class BuilderExtensions
{
    public static void AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options =>
        {
            options.ModelBinderProviders.Insert(0, new DateOnlyModelBinderProvider());
        });
    }
    
    public static void AddIspDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IspDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ISP_Db")));
    }
    
    public static void AddMonitoringDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<MongoDbContext>(); 
    }

    public static void AddAuthDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AuthDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Identity_Db")));
    }

    public static void AddIdentityServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("ISP")
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 0;
        });

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    AuthenticationType = "Jwt",
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
                };
            });
    }
    
    public static void AddDalServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    public static void AddBllServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientService, ClientService>();
        
        builder.Services.AddScoped<IMonitoringService, MonitoringService>();
        
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
        builder.Services.AddScoped<IEmployeeAuthService, EmployeeAuthService>();
    }
}
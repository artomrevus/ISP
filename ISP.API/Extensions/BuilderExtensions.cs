using System.Text;
using ISP.API.ModelBinders;
using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.City;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.DTOs.ISP.ClientStatus;
using ISP.BLL.DTOs.ISP.Employee;
using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.BLL.DTOs.ISP.EmployeeStatus;
using ISP.BLL.DTOs.ISP.House;
using ISP.BLL.DTOs.ISP.Location;
using ISP.BLL.DTOs.ISP.LocationType;
using ISP.BLL.DTOs.ISP.Office;
using ISP.BLL.DTOs.ISP.Street;
using ISP.BLL.Interfaces.Auth;
using ISP.BLL.Interfaces.ISP;
using ISP.BLL.Interfaces.Monitoring;
using ISP.BLL.Services.Auth;
using ISP.BLL.Services.ISP;
using ISP.BLL.Services.Monitoring;
using ISP.DAL;
using ISP.DAL.Data;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;
using ISP.DAL.Repositories;
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
        builder.Services.AddScoped<IUserEmployeeResolver, UserEmployeeResolver>();
        builder.Services.AddScoped<IUserActivityRepository, UserActivityRepository>();
    }
    
    public static void AddBllServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIspBllServices();
        builder.Services.AddMonitoringBllServices();
        builder.Services.AddAuthBllServices();
    }

    private static void AddIspBllServices(this IServiceCollection services)
    {
        services.AddScoped<IIspService<GetCityDto, AddCityDto, UpdateCityDto, CityFilterParameters>, CityService>();
        services.AddScoped<IIspService<GetClientDto, AddClientDto, UpdateClientDto, ClientFilterParameters>, ClientService>();
        services.AddScoped<IIspService<GetClientStatusDto, AddClientStatusDto, UpdateClientStatusDto, ClientStatusFilterParameters>, ClientStatusService>();
        services.AddScoped<IIspService<GetEmployeePositionDto, AddEmployeePositionDto, UpdateEmployeePositionDto, EmployeePositionFilterParameters>, EmployeePositionService>();
        services.AddScoped<IIspService<GetEmployeeDto, AddEmployeeDto, UpdateEmployeeDto, EmployeeFilterParameters>, EmployeeService>();
        services.AddScoped<IIspService<GetEmployeeStatusDto, AddEmployeeStatusDto, UpdateEmployeeStatusDto, EmployeeStatusFilterParameters>, EmployeeStatusService>();
        services.AddScoped<IIspService<GetHouseDto, AddHouseDto, UpdateHouseDto, HouseFilterParameters>, HouseService>();
        services.AddScoped<IIspService<GetLocationDto, AddLocationDto, UpdateLocationDto, LocationFilterParameters>, LocationService>();
        services.AddScoped<IIspService<GetLocationTypeDto, AddLocationTypeDto, UpdateLocationTypeDto, LocationTypeFilterParameters>, LocationTypeService>();
        services.AddScoped<IspService<Street, GetStreetDto, AddStreetDto, UpdateStreetDto, StreetFilterParameters>, StreetService>();
        services.AddScoped<IspService<Office, GetOfficeDto, AddOfficeDto, UpdateOfficeDto, OfficeFilterParameters>, OfficeService>();
    }
    
    private static void AddMonitoringBllServices(this IServiceCollection services)
    {
        services.AddScoped<IMonitoringService, MonitoringService>();
    }
    
    private static void AddAuthBllServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAdminAuthService, AdminAuthService>();
        services.AddScoped<IEmployeeAuthService, EmployeeAuthService>();
        services.AddScoped<IUserService, UserService>();
    }
}
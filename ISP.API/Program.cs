using ISP.API.Extensions;
using ISP.API.Middleware;
using ISP.BLL.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddControllers();

builder.AddIspDbContext();
builder.AddMonitoringDbContext();
builder.AddAuthDbContext();

builder.AddIdentityServices();

builder.AddCorsService();

builder.AddDalServices();
builder.AddBllServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlingMiddleware();

app.UseCors("AllowUiOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
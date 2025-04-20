using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class EmployeePositionsController(IServiceProvider serviceProvider)
    : IspController<EmployeePosition, GetEmployeePositionDto, AddEmployeePositionDto, UpdateEmployeePositionDto, EmployeePositionFilterParameters>(serviceProvider)
{
    
}
using ISP.BLL.DTOs.ISP.EmployeeStatus;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class EmployeeStatusesController(IServiceProvider serviceProvider)
    : IspController<EmployeeStatus, GetEmployeeStatusDto, AddEmployeeStatusDto, UpdateEmployeeStatusDto, EmployeeStatusFilterParameters>(serviceProvider)
{
    
}
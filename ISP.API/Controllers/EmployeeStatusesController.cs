using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.EmployeeStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class EmployeeStatusesController(IServiceProvider serviceProvider)
    : IspController<EmployeeStatus, GetEmployeeStatusDto, AddEmployeeStatusDto, UpdateEmployeeStatusDto, EmployeeStatusFilterParameters>(serviceProvider)
{
    
}
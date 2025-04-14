using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class EmployeePositionsController(IServiceProvider serviceProvider)
    : IspController<EmployeePosition, GetEmployeePositionDto, AddEmployeePositionDto, UpdateEmployeePositionDto, EmployeePositionFilterParameters>(serviceProvider)
{
    
}
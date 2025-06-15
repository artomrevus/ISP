using ISP.BLL.DTOs.ISP.Employee;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

public class EmployeesController(IServiceProvider serviceProvider)
    : IspController<Employee, GetEmployeeDto, AddEmployeeDto, UpdateEmployeeDto, EmployeeFilterParameters>(serviceProvider)
{
    
}
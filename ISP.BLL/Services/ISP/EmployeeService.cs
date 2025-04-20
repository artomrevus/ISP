using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Employee;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Employee, GetEmployeeDto, AddEmployeeDto, UpdateEmployeeDto, EmployeeFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Employee, bool>> BuildFilter(EmployeeFilterParameters filterParameters)
    {
        Expression<Func<Employee, bool>> filter = c => true;
        
        if (filterParameters.EmployeePositionIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.EmployeePositionIds.Contains(x.EmployeePositionId));
        }
        
        if (filterParameters.EmployeeStatusIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.EmployeeStatusIds.Contains(x.EmployeeStatusId));
        }
        
        if (filterParameters.OfficeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.OfficeIds.Contains(x.OfficeId));
        }
        
        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.CityIds.Contains(x.Office.CityId));
        }

        return filter;
    }

    protected override Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            // To add sorting
            _ => null
        };
    }
}
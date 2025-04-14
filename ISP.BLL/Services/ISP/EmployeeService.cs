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
        
        if (filterParameters.EmployeePositionId.HasValue)
        {
            filter = filter.And(x => x.EmployeePositionId == filterParameters.EmployeePositionId.Value);
        }
        
        if (filterParameters.EmployeeStatusId.HasValue)
        {
            filter = filter.And(x => x.EmployeeStatusId == filterParameters.EmployeeStatusId.Value);
        }
        
        if (filterParameters.OfficeId.HasValue)
        {
            filter = filter.And(x => x.OfficeId == filterParameters.OfficeId.Value);
        }
        
        if (filterParameters.CityId.HasValue)
        {
            filter = filter.And(x => x.Office.CityId == filterParameters.CityId.Value);
        }
        
        if (!string.IsNullOrEmpty(filterParameters.EmployeePositionContains))
        {
            filter = filter.And(
                x => x.EmployeePosition.EmployeePositionName!.ToLower().Contains(filterParameters.EmployeePositionContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.EmployeeStatusContains))
        {
            filter = filter.And(
                x => x.EmployeeStatus.EmployeeStatusName!.ToLower().Contains(filterParameters.EmployeeStatusContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.CityContains))
        {
            filter = filter.And(
                x => x.Office.City.CityName!.ToLower().Contains(filterParameters.CityContains.ToLower()));
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
            SortByValues.EmployeePosition => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.EmployeePosition.EmployeePositionName)
                : q => q.OrderByDescending(x => x.EmployeePosition.EmployeePositionName),
            SortByValues.EmployeeStatus => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.EmployeeStatus.EmployeeStatusName)
                : q => q.OrderByDescending(x => x.EmployeeStatus.EmployeeStatusName),
            SortByValues.City => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Office.City.CityName)
                : q => q.OrderByDescending(x => x.Office.City.CityName),
            _ => null
        };
    }
}
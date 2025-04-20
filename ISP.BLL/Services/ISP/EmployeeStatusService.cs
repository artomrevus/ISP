using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.EmployeeStatus;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class EmployeeStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<EmployeeStatus, GetEmployeeStatusDto, AddEmployeeStatusDto, UpdateEmployeeStatusDto, EmployeeStatusFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<EmployeeStatus, bool>> BuildFilter(EmployeeStatusFilterParameters filterParameters)
    {
        Expression<Func<EmployeeStatus, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.EmployeeStatusContains))
        {
            filter = filter.And(x => x.EmployeeStatusName!.ToLower().Contains(filterParameters.EmployeeStatusContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<EmployeeStatus>, IOrderedQueryable<EmployeeStatus>>? BuildSorting(SortingParameters sortingParameters)
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
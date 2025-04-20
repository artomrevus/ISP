using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class EmployeePositionService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<EmployeePosition, GetEmployeePositionDto, AddEmployeePositionDto, UpdateEmployeePositionDto, EmployeePositionFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<EmployeePosition, bool>> BuildFilter(EmployeePositionFilterParameters filterParameters)
    {
        Expression<Func<EmployeePosition, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.EmployeePositionContains))
        {
            filter = filter.And(x => x.EmployeePositionName!.ToLower().Contains(filterParameters.EmployeePositionContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<EmployeePosition>, IOrderedQueryable<EmployeePosition>>? BuildSorting(SortingParameters sortingParameters)
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
using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.LocationType;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class LocationTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<LocationType, GetLocationTypeDto, AddLocationTypeDto, UpdateLocationTypeDto, LocationTypeFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<LocationType, bool>> BuildFilter(LocationTypeFilterParameters filterParameters)
    {
        Expression<Func<LocationType, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.LocationTypeContains))
        {
            filter = filter.And(x => x.LocationTypeName!.ToLower().Contains(filterParameters.LocationTypeContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<LocationType>, IOrderedQueryable<LocationType>>? BuildSorting(SortingParameters sortingParameters)
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
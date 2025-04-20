using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Location;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class LocationService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Location, GetLocationDto, AddLocationDto, UpdateLocationDto, LocationFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Location, bool>> BuildFilter(LocationFilterParameters filterParameters)
    {
        Expression<Func<Location, bool>> filter = c => true;
        
        if (filterParameters.LocationTypeIds.Count > 0) 
        {
            filter = filter.And(x => filterParameters.LocationTypeIds.Contains(x.LocationTypeId));
        }
        
        if (filterParameters.HouseIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.HouseIds.Contains(x.HouseId));
        }
        
        if (filterParameters.StreetIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.StreetIds.Contains(x.House.StreetId));
        }
        
        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.CityIds.Contains(x.House.Street.CityId));
        }

        return filter;
    }

    protected override Func<IQueryable<Location>, IOrderedQueryable<Location>>? BuildSorting(SortingParameters sortingParameters)
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
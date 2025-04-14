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
        
        if (filterParameters.LocationTypeId.HasValue)
        {
            filter = filter.And(x => x.LocationTypeId == filterParameters.LocationTypeId.Value);
        }
        
        if (filterParameters.HouseId.HasValue)
        {
            filter = filter.And(x => x.HouseId == filterParameters.HouseId.Value);
        }
        
        if (filterParameters.StreetId.HasValue)
        {
            filter = filter.And(x => x.House.StreetId == filterParameters.StreetId.Value);
        }
        
        if (filterParameters.CityId.HasValue)
        {
            filter = filter.And(x => x.House.Street.CityId == filterParameters.CityId.Value);
        }
        
        if (!string.IsNullOrEmpty(filterParameters.LocationTypeContains))
        {
            filter = filter.And(
                x => x.LocationType.LocationTypeName!.ToLower().Contains(filterParameters.LocationTypeContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.HouseNumberContains))
        {
            filter = filter.And(
                x => x.House.HouseNumber!.ToLower().Contains(filterParameters.HouseNumberContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.StreetContains))
        {
            filter = filter.And(
                x => x.House.Street.StreetName.ToLower().Contains(filterParameters.StreetContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.CityContains))
        {
            filter = filter.And(
                x => x.House.Street.City.CityName!.ToLower().Contains(filterParameters.CityContains.ToLower()));
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
            SortByValues.LocationType => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.LocationType)
                : q => q.OrderByDescending(x => x.LocationType),
            SortByValues.ApartmentNumber => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.ApartmentNumber)
                : q => q.OrderByDescending(x => x.ApartmentNumber),
            SortByValues.HouseNumber => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.House.HouseNumber)
                : q => q.OrderByDescending(x => x.House.HouseNumber),
            SortByValues.Street => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.House.Street.StreetName)
                : q => q.OrderByDescending(x => x.House.Street.StreetName),
            SortByValues.City => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.House.Street.City.CityName)
                : q => q.OrderByDescending(x => x.House.Street.City.CityName),
            _ => null
        };
    }
}
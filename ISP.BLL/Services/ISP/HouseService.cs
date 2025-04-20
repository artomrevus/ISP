using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.House;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class HouseService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<House, GetHouseDto, AddHouseDto, UpdateHouseDto, HouseFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<House, bool>> BuildFilter(HouseFilterParameters filterParameters)
    {
        Expression<Func<House, bool>> filter = c => true;
        
        if (filterParameters.StreetIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.StreetIds.Contains(x.StreetId));
        }
        
        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.CityIds.Contains(x.Street.CityId));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.HouseNumberContains))
        {
            filter = filter.And(x => x.HouseNumber!.ToLower().Contains(filterParameters.HouseNumberContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<House>, IOrderedQueryable<House>>? BuildSorting(SortingParameters sortingParameters)
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
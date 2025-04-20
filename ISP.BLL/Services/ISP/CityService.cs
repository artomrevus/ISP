using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.City;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class CityService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<City, GetCityDto, AddCityDto, UpdateCityDto, CityFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<City, bool>> BuildFilter(CityFilterParameters filterParameters)
    {
        Expression<Func<City, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.CityContains))
        {
            filter = filter.And(x => x.CityName!.ToLower().Contains(filterParameters.CityContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<City>, IOrderedQueryable<City>>? BuildSorting(SortingParameters sortingParameters)
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
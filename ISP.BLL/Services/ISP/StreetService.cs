using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Street;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class StreetService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Street, GetStreetDto, AddStreetDto, UpdateStreetDto, StreetFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Street, bool>> BuildFilter(StreetFilterParameters filterParameters)
    {
        Expression<Func<Street, bool>> filter = c => true;

        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.CityIds.Contains(x.CityId));
        }

        if (!string.IsNullOrEmpty(filterParameters.StreetNameContains))
        {
            filter = filter.And(x => x.StreetName.ToLower().Contains(filterParameters.StreetNameContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<Street>, IOrderedQueryable<Street>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.StreetName => sortingParameters.Ascending
               ? q => q.OrderBy(x => x.StreetName)
               : q => q.OrderByDescending(x => x.StreetName),
            SortByValues.City => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.City.CityName)
                : q => q.OrderByDescending(x => x.City.CityName),
            _ => null
        };
    }
}
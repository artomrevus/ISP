using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Office;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class OfficeService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Office, GetOfficeDto, AddOfficeDto, UpdateOfficeDto, OfficeFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Office, bool>> BuildFilter(OfficeFilterParameters filterParameters)
    {
        Expression<Func<Office, bool>> filter = c => true;
        
        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.CityIds.Contains(x.CityId));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.AddressContains))
        {
            filter = filter.And(x => x.Address.ToLower().Contains(filterParameters.AddressContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.PhoneNumberContains))
        {
            filter = filter.And(x => x.PhoneNumber.ToLower().Contains(filterParameters.PhoneNumberContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.EmailContains))
        {
            filter = filter.And(x => x.Email.ToLower().Contains(filterParameters.EmailContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<Office>, IOrderedQueryable<Office>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.Address => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Address)
                : q => q.OrderByDescending(x => x.Address),
            SortByValues.PhoneNumber => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.PhoneNumber)
                : q => q.OrderByDescending(x => x.PhoneNumber),
            SortByValues.Email => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Email)
                : q => q.OrderByDescending(x => x.Email),
            SortByValues.City => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.City.CityName)
                : q => q.OrderByDescending(x => x.City.CityName),
            _ => null
        };
    }
}
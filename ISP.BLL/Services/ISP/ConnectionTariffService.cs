using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.ConnectionTariff;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ConnectionTariffService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<ConnectionTariff, GetConnectionTariffDto, AddConnectionTariffDto, UpdateConnectionTariffDto, ConnectionTariffFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<ConnectionTariff, bool>> BuildFilter(ConnectionTariffFilterParameters filterParameters)
    {
        Expression<Func<ConnectionTariff, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.NameContains))
        {
            filter = filter.And(x => x.Name.ToLower().Contains(filterParameters.NameContains.ToLower()));
        }
        
        if (filterParameters.PriceFrom.HasValue)
        {
            filter = filter.And(x => x.Price >= filterParameters.PriceFrom.Value);
        }
        
        if (filterParameters.PriceTo.HasValue)
        {
            filter = filter.And(x => x.Price <= filterParameters.PriceTo.Value);
        }
        
        if (filterParameters.StartDateFrom.HasValue)
        {
            filter = filter.And(x => x.StartDate >= filterParameters.StartDateFrom.Value);
        }
        
        if (filterParameters.StartDateTo.HasValue)
        {
            filter = filter.And(x => x.StartDate <= filterParameters.StartDateTo.Value);
        }
        
        if (filterParameters.EndDateFrom.HasValue)
        {
            filter = filter.And(x => x.EndDate >= filterParameters.EndDateFrom.Value);
        }
        
        if (filterParameters.EndDateTo.HasValue)
        {
            filter = filter.And(x => x.EndDate <= filterParameters.EndDateTo.Value);
        }

        return filter;
    }

    protected override Func<IQueryable<ConnectionTariff>, IOrderedQueryable<ConnectionTariff>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.Name => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Name)
                : q => q.OrderByDescending(x => x.Name),
            SortByValues.Price => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Price)
                : q => q.OrderByDescending(x => x.Price),
            SortByValues.StartDate => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.StartDate)
                : q => q.OrderByDescending(x => x.StartDate),
            SortByValues.EndDate => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.EndDate)
                : q => q.OrderByDescending(x => x.EndDate),
            _ => null
        };
    }
}
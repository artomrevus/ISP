using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.InternetTariff;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InternetTariffService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<InternetTariff, GetInternetTariffDto, AddInternetTariffDto, UpdateInternetTariffDto, InternetTariffFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<InternetTariff, bool>> BuildFilter(InternetTariffFilterParameters filterParameters)
    {
        Expression<Func<InternetTariff, bool>> filter = c => true;
        
        if (filterParameters.LocationTypeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.LocationTypeIds.Contains(x.LocationTypeId));
        }
        
        if (filterParameters.InternetTariffStatusIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.InternetTariffStatusIds.Contains(x.InternetTariffStatusId));
        }
        
        if (filterParameters.PriceFrom.HasValue)
        {
            filter = filter.And(x => x.Price >= filterParameters.PriceFrom.Value);
        }
        
        if (filterParameters.PriceTo.HasValue)
        {
            filter = filter.And(x => x.Price <= filterParameters.PriceTo.Value);
        }
        
        if (filterParameters.InternetSpeedMbitsFrom.HasValue)
        {
            filter = filter.And(x => x.InternetSpeedMbits >= filterParameters.InternetSpeedMbitsFrom.Value);
        }
        
        if (filterParameters.InternetSpeedMbitsTo.HasValue)
        {
            filter = filter.And(x => x.InternetSpeedMbits <= filterParameters.InternetSpeedMbitsTo.Value);
        }
        
        if (!string.IsNullOrEmpty(filterParameters.NameContains))
        {
            filter = filter.And(x => x.Name.ToLower().Contains(filterParameters.NameContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<InternetTariff>, IOrderedQueryable<InternetTariff>>? BuildSorting(SortingParameters sortingParameters)
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
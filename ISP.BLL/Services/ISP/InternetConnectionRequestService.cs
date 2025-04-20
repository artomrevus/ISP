using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.InternetConnectionRequest;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InternetConnectionRequestService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<
        InternetConnectionRequest,
        GetInternetConnectionRequestDto,
        AddInternetConnectionRequestDto,
        UpdateInternetConnectionRequestDto,
        InternetConnectionRequestFilterParameters
    >(unitOfWork, mapper)
{
    protected override Expression<Func<InternetConnectionRequest, bool>> BuildFilter(InternetConnectionRequestFilterParameters filterParameters)
    {
        Expression<Func<InternetConnectionRequest, bool>> filter = c => true;
        
        if (filterParameters.ClientIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.ClientIds.Contains(x.ClientId));
        }
        
        if (filterParameters.InternetTariffIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.InternetTariffIds.Contains(x.InternetTariffId));
        }
        
        if (filterParameters.InternetConnectionRequestStatusIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.InternetConnectionRequestStatusIds.Contains(x.InternetConnectionRequestStatusId));
        }
        
        if (filterParameters.ClientStatusIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.ClientStatusIds.Contains(x.Client.ClientStatusId));
        }
        
        if (filterParameters.LocationIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.LocationIds.Contains(x.Client.LocationId));
        }
        
        if (filterParameters.LocationTypeIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.LocationTypeIds.Contains(x.Client.Location.LocationTypeId));
        }

        if (filterParameters.HouseIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.HouseIds.Contains(x.Client.Location.HouseId));
        }

        if (filterParameters.StreetIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.StreetIds.Contains(x.Client.Location.House.StreetId));
        }
        
        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.CityIds.Contains(x.Client.Location.House.Street.CityId));
        }
        
        if (filterParameters.InternetTariffStatusIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.InternetTariffStatusIds.Contains(x.InternetTariff.InternetTariffStatusId));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.NumberContains))
        {
            filter = filter.And(
                x => x.Number.ToLower().Contains(filterParameters.NumberContains.ToLower()));
        }
        
        if (filterParameters.RequestDateFrom.HasValue)
        {
            filter = filter.And(
                x => x.RequestDate >= filterParameters.RequestDateFrom.Value);
        }
        
        if (filterParameters.RequestDateTo.HasValue)
        {
            filter = filter.And(
                x => x.RequestDate <= filterParameters.RequestDateTo.Value);
        }

        return filter;
    }

    protected override Func<IQueryable<InternetConnectionRequest>, IOrderedQueryable<InternetConnectionRequest>>? BuildSorting(
        SortingParameters sortingParameters)
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
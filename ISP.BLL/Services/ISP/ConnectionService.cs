using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Connection;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ConnectionService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Connection, GetConnectionDto, AddConnectionDto, UpdateConnectionDto, ConnectionFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Connection, bool>> BuildFilter(ConnectionFilterParameters filterParameters)
    {
        Expression<Func<Connection, bool>> filter = c => true;
        
        if (filterParameters.ConnectionTariffIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.ConnectionTariffIds.Contains(x.ConnectionTariffId));
        }
        
        if (filterParameters.InternetConnectionRequestIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.InternetConnectionRequestIds.Contains(x.InternetConnectionRequestId));
        }
        
        if (filterParameters.EmployeeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.EmployeeIds.Contains(x.EmployeeId));
        }
        
        if (filterParameters.OfficeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.OfficeIds.Contains(x.Employee.OfficeId));
        }
        
        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.CityIds.Contains(x.Employee.Office.CityId));
        }
        
        if (filterParameters.ClientIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.ClientIds.Contains(x.InternetConnectionRequest.ClientId));
        }
        
        if (filterParameters.InternetTariffIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.InternetTariffIds.Contains(x.InternetConnectionRequest.InternetTariffId));
        }
        
        if (filterParameters.InternetConnectionRequestStatusIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.InternetConnectionRequestStatusIds.Contains(x.InternetConnectionRequest.InternetConnectionRequestStatusId));
        }
        
        if (filterParameters.ClientStatusIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.ClientStatusIds.Contains(x.InternetConnectionRequest.Client.ClientStatusId));
        }
        
        if (filterParameters.LocationIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.LocationIds.Contains(x.InternetConnectionRequest.Client.LocationId));
        }
        
        if (filterParameters.LocationTypeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.LocationTypeIds.Contains(x.InternetConnectionRequest.Client.Location.LocationTypeId));
        }
    
        if (filterParameters.HouseIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.HouseIds.Contains(x.InternetConnectionRequest.Client.Location.HouseId));
        }
    
        if (filterParameters.StreetIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.StreetIds.Contains(x.InternetConnectionRequest.Client.Location.House.StreetId));
        }
        
        if (filterParameters.InternetTariffStatusIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.InternetTariffStatusIds.Contains(x.InternetConnectionRequest.InternetTariff.InternetTariffStatusId));
        }
        
        if (filterParameters.TotalPriceFrom.HasValue)
        {
            filter = filter.And(x => x.TotalPrice >= filterParameters.TotalPriceFrom.Value);
        }
        
        if (filterParameters.TotalPriceTo.HasValue)
        {
            filter = filter.And(x => x.TotalPrice <= filterParameters.TotalPriceTo.Value);
        }
        
        if (filterParameters.ConnectionDateFrom.HasValue)
        {
            filter = filter.And(
                x => x.ConnectionDate >= filterParameters.ConnectionDateFrom.Value);
        }
        
        if (filterParameters.ConnectionDateTo.HasValue)
        {
            filter = filter.And(
                x => x.ConnectionDate <= filterParameters.ConnectionDateTo.Value);
        }
    
        return filter;
    }
    
    protected override Func<IQueryable<Connection>, IOrderedQueryable<Connection>>? BuildSorting(
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
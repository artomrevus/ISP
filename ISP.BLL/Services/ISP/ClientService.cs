using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ClientService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Client, GetClientDto, AddClientDto, UpdateClientDto, ClientFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Client, bool>> BuildFilter(ClientFilterParameters filterParameters)
    {
        Expression<Func<Client, bool>> filter = c => true;
        
        if (filterParameters.ClientStatusIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.ClientStatusIds.Contains(x.ClientStatusId));
        }
        
        if (filterParameters.LocationIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.LocationIds.Contains(x.LocationId));
        }
        
        if (filterParameters.LocationTypeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.LocationTypeIds.Contains(x.Location.LocationTypeId));
        }
        
        if (filterParameters.HouseIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.HouseIds.Contains(x.Location.HouseId));
        }
        
        if (filterParameters.StreetIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.StreetIds.Contains(x.Location.House.StreetId));
        }
        
        if (filterParameters.CityIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.CityIds.Contains(x.Location.House.Street.CityId));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.FirstNameContains))
        {
            filter = filter.And(c => c.FirstName.ToLower().Contains(filterParameters.FirstNameContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.LastNameContains))
        {
            filter = filter.And(c => c.LastName.ToLower().Contains(filterParameters.LastNameContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.PhoneNumberContains))
        {
            filter = filter.And(c => c.PhoneNumber.ToLower().Contains(filterParameters.PhoneNumberContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.EmailContains))
        {
            filter = filter.And(c => c.Email.ToLower().Contains(filterParameters.EmailContains.ToLower()));
        }
        
        if (filterParameters.RegistrationDateFrom.HasValue)
        {
            filter = filter.And(c => c.RegistrationDate >= filterParameters.RegistrationDateFrom.Value);
        }

        if (filterParameters.RegistrationDateTo.HasValue)
        {
            filter = filter.And(c => c.RegistrationDate <= filterParameters.RegistrationDateTo.Value);
        }

        return filter;
    }

    protected override Func<IQueryable<Client>, IOrderedQueryable<Client>>? BuildSorting(SortingParameters sortingParameters)
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
using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ClientService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Client, GetClientDto, AddClientDto, UpdateClientDto, ClientFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Client, bool>> BuildFilter(ClientFilterParameters filterParameters)
    {
        Expression<Func<Client, bool>> filter = c => true;
        
        if (filterParameters.ClientStatusId.HasValue)
        {
            filter = filter.And(c => c.ClientStatusId == filterParameters.ClientStatusId.Value);
        }
        
        if (filterParameters.LocationId.HasValue)
        {
            filter = filter.And(c => c.LocationId == filterParameters.LocationId.Value);
        }
        
        if (filterParameters.LocationTypeId.HasValue)
        {
            filter = filter.And(c => c.Location.LocationTypeId == filterParameters.LocationTypeId.Value);
        }
        
        if (filterParameters.HouseId.HasValue)
        {
            filter = filter.And(c => c.Location.HouseId == filterParameters.HouseId.Value);
        }
        
        if (filterParameters.StreetId.HasValue)
        {
            filter = filter.And(c => c.Location.House.StreetId == filterParameters.StreetId.Value);
        }
        
        if (filterParameters.CityId.HasValue)
        {
            filter = filter.And(c => c.Location.House.Street.CityId == filterParameters.CityId.Value);
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
        
        if (!string.IsNullOrEmpty(filterParameters.ClientStatusContains))
        {
            filter = filter.And(
                c => c.ClientStatus.ClientStatusName!.ToLower().Contains(filterParameters.ClientStatusContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.HouseNumberContains))
        {
            filter = filter.And(
                c => c.Location.House.HouseNumber!.ToLower().Contains(filterParameters.HouseNumberContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.StreetContains))
        {
            filter = filter.And(
                c => c.Location.House.Street.StreetName.ToLower().Contains(filterParameters.StreetContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.CityContains))
        {
            filter = filter.And(
                c => c.Location.House.Street.City.CityName!.ToLower().Contains(filterParameters.CityContains.ToLower()));
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
            SortByValues.FirstName => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.FirstName)
                : q => q.OrderByDescending(c => c.FirstName),
            SortByValues.LastName => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.LastName)
                : q => q.OrderByDescending(c => c.LastName),
            SortByValues.Email => sortingParameters.Ascending 
                ? q => q.OrderBy(c => c.Email) 
                : q => q.OrderByDescending(c => c.Email),
            SortByValues.RegistrationDate => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.RegistrationDate)
                : q => q.OrderByDescending(c => c.RegistrationDate),
            SortByValues.ClientStatus => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.ClientStatus.ClientStatusName)
                : q => q.OrderByDescending(c => c.ClientStatus.ClientStatusName),
            SortByValues.HouseNumber => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.Location.House.HouseNumber)
                : q => q.OrderByDescending(c => c.Location.House.HouseNumber),
            SortByValues.Street => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.Location.House.Street.StreetName)
                : q => q.OrderByDescending(c => c.Location.House.Street.StreetName),
            SortByValues.City => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.Location.House.Street.City.CityName)
                : q => q.OrderByDescending(c => c.Location.House.Street.City.CityName),
            _ => null
        };
    }
}
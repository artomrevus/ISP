using System.Linq.Expressions;
using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.Exceptions;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.BLL.Mappers;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ClientService(
    IUnitOfWork unitOfWork)
    : IClientService
{
    private readonly IGenericRepository<Client> _clientRepository = unitOfWork.Repository<Client>();
    
    public async Task<IEnumerable<GetClientDto>> GetAllAsync(
        PaginationParameters pagination, 
        ClientFilterParameters filter, 
        SortingParameters sorting)
    {
        var skipRecords = (pagination.PageNumber - 1) * pagination.PageSize;
        var takeRecords = pagination.PageSize;
        var filterExpression = BuildFilter(filter);
        var orderByFunc = BuildOrderBy(sorting);

        var clients = await _clientRepository.GetAsync(
            skipRecords,
            takeRecords,
            filterExpression,
            orderByFunc);
        
        return clients.ToGetClientDtos();
    }

    public async Task<GetClientDto> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if (client is null)
        {
            throw new NotFoundException($"Client with id '{id}' not found.");
        }

        return client.ToGetClientDto();
    }

    public async Task<GetClientDto> AddAsync(AddClientDto dto)
    {
        var client = dto.ToClient();
        client.CreateDateTime = DateTime.Now;
        
        await _clientRepository.AddAsync(client);
        await unitOfWork.SaveChangesAsync();
            
        return client.ToGetClientDto();
    }

    public async Task<GetClientDto> UpdateAsync(UpdateClientDto dto)
    {
        var clientToUpdate = await _clientRepository.GetByIdAsync(dto.Id);
            
        if (clientToUpdate is null)
        {
            throw new NotFoundException($"Client with id '{dto.Id}' not found.");
        }
        
        var updatedClient = dto.ToClient();
        updatedClient.CreateDateTime = clientToUpdate.CreateDateTime;
        updatedClient.UpdateDateTime = DateTime.Now;
            
        await _clientRepository.UpdateAsync(updatedClient);
        await unitOfWork.SaveChangesAsync();
            
        return updatedClient.ToGetClientDto();
    }

    public async Task DeleteAsync(int id)
    {
        var clientToDelete = await _clientRepository.GetByIdAsync(id);
        
        if (clientToDelete is null)
        {
            throw new NotFoundException($"Client with id '{id}' not found.");
        }
        
        await _clientRepository.DeleteAsync(clientToDelete);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<int> GetCountAsync(ClientFilterParameters filter)
    {
        var filterExpression = BuildFilter(filter);
        return await _clientRepository.CountAsync(filterExpression);
    }

    private static Expression<Func<Client, bool>> BuildFilter(ClientFilterParameters filterParameters)
    {
        Expression<Func<Client, bool>> filter = c => true;
        
        if (filterParameters.ClientStatusId.HasValue)
        {
            filter = filter.And(c => c.ClientStatusId == filterParameters.ClientStatusId.Value);
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
        
        if (!string.IsNullOrEmpty(filterParameters.StreetContains))
        {
            filter = filter.And(c => c.Location.House.Street.StreetName.ToLower().Contains(filterParameters.StreetContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.CityContains))
        {
            filter = filter.And(c => c.Location.House.Street.City.CityName!.ToLower().Contains(filterParameters.CityContains.ToLower()));
        }

        return filter;
    }

    private static Func<IQueryable<Client>, IOrderedQueryable<Client>>? BuildOrderBy(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            "firstname" => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.FirstName)
                : q => q.OrderByDescending(c => c.FirstName),
            "lastname" => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.LastName)
                : q => q.OrderByDescending(c => c.LastName),
            "email" => sortingParameters.Ascending 
                ? q => q.OrderBy(c => c.Email) 
                : q => q.OrderByDescending(c => c.Email),
            "registrationdate" => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.RegistrationDate)
                : q => q.OrderByDescending(c => c.RegistrationDate),
            "status" => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.ClientStatus.ClientStatusName)
                : q => q.OrderByDescending(c => c.ClientStatus.ClientStatusName),
            "street" => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.Location.House.Street.StreetName)
                : q => q.OrderByDescending(c => c.Location.House.Street.StreetName),
            "city" => sortingParameters.Ascending
                ? q => q.OrderBy(c => c.Location.House.Street.City.CityName)
                : q => q.OrderByDescending(c => c.Location.House.Street.City.CityName),
            _ => null
        };
    }
}
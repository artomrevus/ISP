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
    
    public async Task<IEnumerable<GetClientDto>> GetAllClientsAsync(
        PaginationParameters pagination, 
        ClientFilterParameters filter, 
        SortingParameters sorting)
    {
        var skipRecords = (pagination.PageNumber - 1) * pagination.PageSize;
        var takeRecords =pagination.PageSize;
        var filterExpression = BuildFilter(filter);
        var orderByFunc = BuildOrderBy(sorting);

        var clients = await _clientRepository.GetAsync(
            skipRecords,
            takeRecords,
            filterExpression,
            orderByFunc);
        
        return clients.ToGetClientDtos();
    }

    public async Task<GetClientDto> GetClientByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if (client is null)
        {
            throw new NotFoundException($"Client with id '{id}' not found.");
        }

        return client.ToGetClientDto();
    }

    public async Task<GetClientDto> AddClientAsync(AddClientDto addClientDto)
    {
        var client = addClientDto.ToClient();
        client.CreateDateTime = DateTime.Now;
        
        await _clientRepository.AddAsync(client);
        await unitOfWork.SaveChangesAsync();
            
        return client.ToGetClientDto();
    }

    public async Task<GetClientDto> UpdateClientAsync(UpdateClientDto updateClientDto)
    {
        var clientToUpdate = await _clientRepository.GetByIdAsync(updateClientDto.Id);
            
        if (clientToUpdate is null)
        {
            throw new NotFoundException($"Client with id '{updateClientDto.Id}' not found.");
        }
        
        var updatedClient = updateClientDto.ToClient();
        updatedClient.CreateDateTime = clientToUpdate.CreateDateTime;
        updatedClient.UpdateDateTime = DateTime.Now;
            
        await _clientRepository.UpdateAsync(updatedClient);
        await unitOfWork.SaveChangesAsync();
            
        return updatedClient.ToGetClientDto();
    }

    public async Task DeleteClientAsync(int id)
    {
        var clientToDelete = await _clientRepository.GetByIdAsync(id);
        
        if (clientToDelete is null)
        {
            throw new NotFoundException($"Client with id '{id}' not found.");
        }
        
        await _clientRepository.DeleteAsync(clientToDelete);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<int> GetTotalCountAsync(string? searchTerm = null)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return await _clientRepository.CountAsync();
        }

        Expression<Func<Client, bool>> filter = 
            c =>
            c.FirstName.Contains(searchTerm) ||
            c.LastName.Contains(searchTerm) ||
            c.Email.Contains(searchTerm) ||
            c.PhoneNumber.Contains(searchTerm);
            
        return await _clientRepository.CountAsync(filter);
    }

    private static Expression<Func<Client, bool>> BuildFilter(ClientFilterParameters filterParameters)
    {
        Expression<Func<Client, bool>> filter = c => true;
        
        if (filterParameters.ClientStatusIds.Count > 0)
        {
            filter = filter.And(c => filterParameters.ClientStatusIds.Contains(c.ClientStatusId));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.FirstNameContains))
        {
            filter = filter.And(c => c.FirstName.Contains(filterParameters.FirstNameContains));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.LastNameContains))
        {
            filter = filter.And(c => c.LastName.Contains(filterParameters.LastNameContains));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.PhoneNumberContains))
        {
            filter = filter.And(c => c.PhoneNumber.Contains(filterParameters.PhoneNumberContains));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.EmailContains))
        {
            filter = filter.And(c => c.Email.Contains(filterParameters.EmailContains));
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
            filter = filter.And(c => c.Location.House.Street.StreetName.Contains(filterParameters.StreetContains));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.CityContains))
        {
            filter = filter.And(c => c.Location.House.Street.City.CityName!.Contains(filterParameters.CityContains));
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
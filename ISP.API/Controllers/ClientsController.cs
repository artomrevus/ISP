using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.Interfaces.ISP;
using ISP.BLL.Interfaces.Monitoring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(
    IClientService clientService, 
    IMonitoringService monitoringService)
    : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery]PaginationParameters pagination,
        [FromQuery]ClientFilterParameters filter,
        [FromQuery]SortingParameters sorting)
    {
        var clients = await clientService.GetAllClientsAsync(pagination, filter, sorting);
        await monitoringService.LogActivityAsync(
            User,
            "Client",
            "Read", 
            $"Retrieved {clients.Count()} clients.");
        
        return Ok(clients);
    }

    [Authorize(Roles = "Admin, NetworkTechnician")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var client = await clientService.GetClientByIdAsync(id);
        await monitoringService.LogActivityAsync(
            User,
            "Client", 
            "Read",
            $"Retrieved client:" +
            $"\n    - First name: {client.FirstName}." +
            $"\n    - Last name: {client.LastName}." + 
            $"\n    - Phone number: {client.PhoneNumber}." + 
            $"\n    - Email: {client.Email}." + 
            $"\n    - Registration date: {client.RegistrationDate}.");
        
        return Ok(client);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddClientDto addClientDto)
    {
        var result = await clientService.AddClientAsync(addClientDto);
        await monitoringService.LogActivityAsync(
            User,
            "Client", 
            "Create",
            "Created client:" +
            $"\n    - First name: {result.FirstName}." +
            $"\n    - Last name: {result.LastName}." + 
            $"\n    - Phone number: {result.PhoneNumber}." + 
            $"\n    - Email: {result.Email}." + 
            $"\n    - Registration date: {result.RegistrationDate}.");
        
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClientDto updateClientDto)
    {
        var result = await clientService.UpdateClientAsync(updateClientDto);
        await monitoringService.LogActivityAsync(
            User,
            "Client",
            "Update",
            "Updated client:" +
            $"\n    - First name: {result.FirstName}." +
            $"\n    - Last name: {result.LastName}." + 
            $"\n    - Phone number: {result.PhoneNumber}." + 
            $"\n    - Email: {result.Email}." + 
            $"\n    - Registration date: {result.RegistrationDate}.");
        
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await clientService.DeleteClientAsync(id);
        await monitoringService.LogActivityAsync(
            User,
            "Client", 
            "Delete",
            "Deleted client.");
        
        return NoContent();
    }
}
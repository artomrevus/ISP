using ISP.BLL.DTOs.ISP.Client;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "ShortCache")]
public class ClientsController(IServiceProvider serviceProvider)
    : IspController<Client, GetClientDto, AddClientDto, UpdateClientDto, ClientFilterParameters>(serviceProvider)
{
    
}
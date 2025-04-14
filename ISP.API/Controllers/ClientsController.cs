using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Client;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

public class ClientsController(IServiceProvider serviceProvider)
    : IspController<Client, GetClientDto, AddClientDto, UpdateClientDto, ClientFilterParameters>(serviceProvider)
{
    
}
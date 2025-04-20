using ISP.BLL.DTOs.ISP.ClientStatus;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class ClientStatusesController(IServiceProvider serviceProvider)
    : IspController<ClientStatus, GetClientStatusDto, AddClientStatusDto, UpdateClientStatusDto, ClientStatusFilterParameters>(serviceProvider)
{
    
}
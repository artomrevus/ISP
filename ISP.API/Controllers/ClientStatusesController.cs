using ISP.BLL.DTOs.ISP.ClientStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class ClientStatusesController(IServiceProvider serviceProvider)
    : IspController<ClientStatus, GetClientStatusDto, AddClientStatusDto, UpdateClientStatusDto, ClientStatusFilterParameters>(serviceProvider)
{
    
}
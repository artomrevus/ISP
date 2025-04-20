using ISP.BLL.DTOs.ISP.Connection;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class ConnectionsController(IServiceProvider serviceProvider)
    : IspController<Connection, GetConnectionDto, AddConnectionDto, UpdateConnectionDto, ConnectionFilterParameters>(serviceProvider)
{
    
}
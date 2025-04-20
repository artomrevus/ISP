using ISP.BLL.DTOs.ISP.ConnectionEquipment;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class ConnectionEquipmentsController(IServiceProvider serviceProvider)
    : IspController<ConnectionEquipment, GetConnectionEquipmentDto, AddConnectionEquipmentDto, UpdateConnectionEquipmentDto, ConnectionEquipmentFilterParameters>(serviceProvider)
{
    
}
using ISP.BLL.DTOs.ISP.ConnectionTariff;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class ConnectionTariffsController(IServiceProvider serviceProvider)
    : IspController<ConnectionTariff, GetConnectionTariffDto, AddConnectionTariffDto, UpdateConnectionTariffDto, ConnectionTariffFilterParameters>(serviceProvider)
{
    
}
using ISP.BLL.DTOs.ISP.ConnectionTariff;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

public class ConnectionTariffsController(IServiceProvider serviceProvider)
    : IspController<ConnectionTariff, GetConnectionTariffDto, AddConnectionTariffDto, UpdateConnectionTariffDto, ConnectionTariffFilterParameters>(serviceProvider)
{
    
}
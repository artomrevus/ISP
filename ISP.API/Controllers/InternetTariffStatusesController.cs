using ISP.BLL.DTOs.ISP.InternetTariffStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class InternetTariffStatusesController(IServiceProvider serviceProvider)
    : IspController<InternetTariffStatus, GetInternetTariffStatusDto, AddInternetTariffStatusDto, UpdateInternetTariffStatusDto, InternetTariffStatusFilterParameters>(serviceProvider)
{
    
}
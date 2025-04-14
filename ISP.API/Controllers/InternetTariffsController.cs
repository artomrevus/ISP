using ISP.BLL.DTOs.ISP.InternetTariff;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class InternetTariffsController(IServiceProvider serviceProvider)
    : IspController<InternetTariff, GetInternetTariffDto, AddInternetTariffDto, UpdateInternetTariffDto, InternetTariffFilterParameters>(serviceProvider)
{
    
}
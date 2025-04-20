using ISP.BLL.DTOs.ISP.InternetTariff;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class InternetTariffsController(IServiceProvider serviceProvider)
    : IspController<InternetTariff, GetInternetTariffDto, AddInternetTariffDto, UpdateInternetTariffDto, InternetTariffFilterParameters>(serviceProvider)
{
    
}
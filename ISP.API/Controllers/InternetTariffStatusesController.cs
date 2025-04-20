using ISP.BLL.DTOs.ISP.InternetTariffStatus;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class InternetTariffStatusesController(IServiceProvider serviceProvider)
    : IspController<InternetTariffStatus, GetInternetTariffStatusDto, AddInternetTariffStatusDto, UpdateInternetTariffStatusDto, InternetTariffStatusFilterParameters>(serviceProvider)
{
    
}
using ISP.BLL.DTOs.ISP.InternetConnectionRequestStatus;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class InternetConnectionRequestStatusesController(IServiceProvider serviceProvider)
    : IspController<
        InternetConnectionRequestStatus, 
        GetInternetConnectionRequestStatusDto,
        AddInternetConnectionRequestStatusDto,
        UpdateInternetConnectionRequestStatusDto,
        InternetConnectionRequestStatusFilterParameters
    >(serviceProvider)
{
    
}
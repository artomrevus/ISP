using ISP.BLL.DTOs.ISP.InternetConnectionRequestStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

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
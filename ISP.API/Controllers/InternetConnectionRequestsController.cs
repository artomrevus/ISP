using ISP.BLL.DTOs.ISP.InternetConnectionRequest;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class InternetConnectionRequestsController(IServiceProvider serviceProvider)
    : IspController<
        InternetConnectionRequest,
        GetInternetConnectionRequestDto,
        AddInternetConnectionRequestDto,
        UpdateInternetConnectionRequestDto,
        InternetConnectionRequestFilterParameters
    >(serviceProvider)
{
    
}
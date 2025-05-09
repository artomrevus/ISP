using ISP.BLL.DTOs.ISP.PurchaseStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class PurchaseStatusesController(IServiceProvider serviceProvider)
    : IspController<PurchaseStatus, GetPurchaseStatusDto, AddPurchaseStatusDto, UpdatePurchaseStatusDto, PurchaseStatusFilterParameters>(serviceProvider)
{
    
}
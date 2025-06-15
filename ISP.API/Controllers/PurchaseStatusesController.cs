using ISP.BLL.DTOs.ISP.PurchaseStatus;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class PurchaseStatusesController(IServiceProvider serviceProvider)
    : IspController<PurchaseStatus, GetPurchaseStatusDto, AddPurchaseStatusDto, UpdatePurchaseStatusDto, PurchaseStatusFilterParameters>(serviceProvider)
{
    
}
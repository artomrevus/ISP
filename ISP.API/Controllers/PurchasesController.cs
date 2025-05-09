using ISP.BLL.DTOs.ISP.Purchase;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class PurchasesController(IServiceProvider serviceProvider)
    : IspController<Purchase, GetPurchaseDto, AddPurchaseDto, UpdatePurchaseDto, PurchaseFilterParameters>(serviceProvider)
{
    
}
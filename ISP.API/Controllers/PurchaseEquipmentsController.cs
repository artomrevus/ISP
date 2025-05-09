using ISP.BLL.DTOs.ISP.PurchaseEquipment;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class PurchaseEquipmentsController(IServiceProvider serviceProvider)
    : IspController<PurchaseEquipment, GetPurchaseEquipmentDto, AddPurchaseEquipmentDto, UpdatePurchaseEquipmentDto, PurchaseEquipmentFilterParameters>(serviceProvider)
{
    
}
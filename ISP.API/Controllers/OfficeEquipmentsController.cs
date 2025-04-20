using ISP.BLL.DTOs.ISP.OfficeEquipment;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class OfficeEquipmentsController(IServiceProvider serviceProvider)
    : IspController<OfficeEquipment, GetOfficeEquipmentDto, AddOfficeEquipmentDto, UpdateOfficeEquipmentDto, OfficeEquipmentFilterParameters>(serviceProvider)
{
    
}
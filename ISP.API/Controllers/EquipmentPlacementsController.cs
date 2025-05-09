using ISP.BLL.DTOs.ISP.Candidate;
using ISP.BLL.DTOs.ISP.EquipmentPlacement;
using ISP.BLL.DTOs.ISP.Supplier;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class EquipmentPlacementsController(IServiceProvider serviceProvider)
    : IspController<EquipmentPlacement, GetEquipmentPlacementDto, AddEquipmentPlacementDto, UpdateEquipmentPlacementDto, EquipmentPlacementFilterParameters>(serviceProvider)
{
    
}
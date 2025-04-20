using ISP.BLL.DTOs.ISP.Equipment;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "ShortCache")]
public class EquipmentsController(IServiceProvider serviceProvider)
    : IspController<Equipment, GetEquipmentDto, AddEquipmentDto, UpdateEquipmentDto, EquipmentFilterParameters>(serviceProvider)
{
    
}
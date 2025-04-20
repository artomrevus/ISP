using ISP.BLL.DTOs.ISP.EquipmentType;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class EquipmentTypesController(IServiceProvider serviceProvider)
    : IspController<EquipmentType, GetEquipmentTypeDto, AddEquipmentTypeDto, UpdateEquipmentTypeDto, EquipmentTypeFilterParameters>(serviceProvider)
{
    
}
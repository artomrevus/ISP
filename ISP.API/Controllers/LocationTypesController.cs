using ISP.BLL.DTOs.ISP.LocationType;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class LocationTypesController(IServiceProvider serviceProvider)
    : IspController<LocationType, GetLocationTypeDto, AddLocationTypeDto, UpdateLocationTypeDto, LocationTypeFilterParameters>(serviceProvider)
{
    
}
using ISP.BLL.DTOs.ISP.Location;
using ISP.BLL.DTOs.ISP.LocationType;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class LocationTypesController(IServiceProvider serviceProvider)
    : IspController<LocationType, GetLocationTypeDto, AddLocationTypeDto, UpdateLocationTypeDto, LocationTypeFilterParameters>(serviceProvider)
{
    
}
using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Location;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class LocationsController(IServiceProvider serviceProvider)
    : IspController<Location, GetLocationDto, AddLocationDto, UpdateLocationDto, LocationFilterParameters>(serviceProvider)
{
    
}
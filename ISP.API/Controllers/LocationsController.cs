using ISP.BLL.DTOs.ISP.Location;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

public class LocationsController(IServiceProvider serviceProvider)
    : IspController<Location, GetLocationDto, AddLocationDto, UpdateLocationDto, LocationFilterParameters>(serviceProvider)
{
    
}
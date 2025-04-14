using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Location;
using ISP.BLL.DTOs.ISP.LocationType;
using ISP.BLL.DTOs.ISP.Street;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class StreetsController(IServiceProvider serviceProvider)
    : IspController<Street, GetStreetDto, AddStreetDto, UpdateStreetDto, StreetFilterParameters>(serviceProvider)
{
    
}
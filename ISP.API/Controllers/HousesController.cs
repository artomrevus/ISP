using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.House;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class HousesController(IServiceProvider serviceProvider)
    : IspController<House, GetHouseDto, AddHouseDto, UpdateHouseDto, HouseFilterParameters>(serviceProvider)
{
    
}
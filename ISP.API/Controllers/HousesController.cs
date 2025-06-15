using ISP.BLL.DTOs.ISP.House;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

public class HousesController(IServiceProvider serviceProvider)
    : IspController<House, GetHouseDto, AddHouseDto, UpdateHouseDto, HouseFilterParameters>(serviceProvider)
{
    
}
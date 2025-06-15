using ISP.BLL.DTOs.ISP.City;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class CitiesController(IServiceProvider serviceProvider)
    : IspController<City, GetCityDto, AddCityDto, UpdateCityDto, CityFilterParameters>(serviceProvider)
{
    
}
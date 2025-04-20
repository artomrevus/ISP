using ISP.BLL.DTOs.ISP.City;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class CitiesController(IServiceProvider serviceProvider)
    : IspController<City, GetCityDto, AddCityDto, UpdateCityDto, CityFilterParameters>(serviceProvider)
{
    
}
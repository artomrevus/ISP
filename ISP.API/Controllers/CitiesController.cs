using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.City;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

public class CitiesController(IServiceProvider serviceProvider)
    : IspController<City, GetCityDto, AddCityDto, UpdateCityDto, CityFilterParameters>(serviceProvider)
{
    
}
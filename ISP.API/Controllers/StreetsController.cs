using ISP.BLL.DTOs.ISP.Street;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class StreetsController(IServiceProvider serviceProvider)
    : IspController<Street, GetStreetDto, AddStreetDto, UpdateStreetDto, StreetFilterParameters>(serviceProvider)
{
    
}
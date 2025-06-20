using ISP.BLL.DTOs.ISP.Office;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

public class OfficesController(IServiceProvider serviceProvider)
    : IspController<Office, GetOfficeDto, AddOfficeDto, UpdateOfficeDto, OfficeFilterParameters>(serviceProvider)
{
    
}
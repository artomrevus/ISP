using ISP.BLL.DTOs.ISP.VacancyStatus;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class VacancyStatusesController(IServiceProvider serviceProvider)
    : IspController<VacancyStatus, GetVacancyStatusDto, AddVacancyStatusDto, UpdateVacancyStatusDto, VacancyStatusFilterParameters>(serviceProvider)
{
    
}
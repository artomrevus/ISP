using ISP.BLL.DTOs.ISP.VacancyStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class VacancyStatusesController(IServiceProvider serviceProvider)
    : IspController<VacancyStatus, GetVacancyStatusDto, AddVacancyStatusDto, UpdateVacancyStatusDto, VacancyStatusFilterParameters>(serviceProvider)
{
    
}
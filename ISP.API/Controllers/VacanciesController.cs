using ISP.BLL.DTOs.ISP.Vacancy;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class VacanciesController(IServiceProvider serviceProvider)
    : IspController<Vacancy, GetVacancyDto, AddVacancyDto, UpdateVacancyDto, VacancyFilterParameters>(serviceProvider)
{
    
}
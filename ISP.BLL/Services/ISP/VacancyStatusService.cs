using AutoMapper;
using ISP.BLL.DTOs.ISP.Vacancy;
using ISP.BLL.DTOs.ISP.VacancyStatus;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class VacancyStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<VacancyStatus, GetVacancyStatusDto, AddVacancyStatusDto, UpdateVacancyStatusDto, VacancyStatusFilterParameters>(unitOfWork, mapper)
{
   
}
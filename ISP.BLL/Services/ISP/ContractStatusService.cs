using AutoMapper;
using ISP.BLL.DTOs.ISP.ContractStatus;
using ISP.BLL.DTOs.ISP.Vacancy;
using ISP.BLL.DTOs.ISP.VacancyStatus;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ContractStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<ContractStatus, GetContractStatusDto, AddContractStatusDto, UpdateContractStatusDto, ContractStatusFilterParameters>(unitOfWork, mapper)
{
   
}
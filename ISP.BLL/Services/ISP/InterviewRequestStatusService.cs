using AutoMapper;
using ISP.BLL.DTOs.ISP.InterviewRequestStatus;
using ISP.BLL.DTOs.ISP.Vacancy;
using ISP.BLL.DTOs.ISP.VacancyStatus;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InterviewRequestStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<
        InterviewRequestStatus,
        GetInterviewRequestStatusDto,
        AddInterviewRequestStatusDto,
        UpdateInterviewRequestStatusDto,
        InterviewRequestStatusFilterParameters
    >(unitOfWork, mapper)
{
   
}
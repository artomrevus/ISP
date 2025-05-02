using AutoMapper;
using ISP.BLL.DTOs.ISP.InterviewResult;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InterviewResultService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<InterviewResult, GetInterviewResultDto, AddInterviewResultDto, UpdateInterviewResultDto, InterviewResultFilterParameters>(unitOfWork, mapper)
{
   
}
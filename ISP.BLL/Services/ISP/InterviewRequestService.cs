using AutoMapper;
using ISP.BLL.DTOs.ISP.Interview;
using ISP.BLL.DTOs.ISP.InterviewRequest;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InterviewRequestService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<InterviewRequest, GetInterviewRequestDto, AddInterviewRequestDto, UpdateInterviewRequestDto, InterviewRequestFilterParameters>(unitOfWork, mapper)
{
    
}
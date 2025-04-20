using AutoMapper;
using ISP.BLL.DTOs.ISP.Interview;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InterviewService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Interview, GetInterviewDto, AddInterviewDto, UpdateInterviewDto, InterviewFilterParameters>(unitOfWork, mapper)
{
    
}
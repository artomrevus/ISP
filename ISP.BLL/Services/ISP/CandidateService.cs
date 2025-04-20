using AutoMapper;
using ISP.BLL.DTOs.ISP.Candidate;
using ISP.BLL.DTOs.ISP.Interview;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Candidate, GetCandidateDto, AddCandidateDto, UpdateCandidateDto, CandidateFilterParameters>(unitOfWork, mapper)
{
    
}
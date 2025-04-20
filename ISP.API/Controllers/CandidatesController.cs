using ISP.BLL.DTOs.ISP.Candidate;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class CandidatesController(IServiceProvider serviceProvider)
    : IspController<Candidate, GetCandidateDto, AddCandidateDto, UpdateCandidateDto, CandidateFilterParameters>(serviceProvider)
{
    
}
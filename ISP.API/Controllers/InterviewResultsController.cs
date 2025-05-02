using ISP.BLL.DTOs.ISP.InterviewResult;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class InterviewResultsController(IServiceProvider serviceProvider)
    : IspController<InterviewResult, GetInterviewResultDto, AddInterviewResultDto, UpdateInterviewResultDto, InterviewResultFilterParameters>(serviceProvider)
{
    
}
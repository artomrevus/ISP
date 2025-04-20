using ISP.BLL.DTOs.ISP.InterviewRequest;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class InterviewRequestsController(IServiceProvider serviceProvider)
    : IspController<InterviewRequest, GetInterviewRequestDto, AddInterviewRequestDto, UpdateInterviewRequestDto, InterviewRequestFilterParameters>(serviceProvider)
{
    
}
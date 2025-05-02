using ISP.BLL.DTOs.ISP.InterviewRequestStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class InterviewRequestStatusesController(IServiceProvider serviceProvider)
    : IspController<
        InterviewRequestStatus, 
        GetInterviewRequestStatusDto,
        AddInterviewRequestStatusDto,
        UpdateInterviewRequestStatusDto, 
        InterviewRequestStatusFilterParameters
    >(serviceProvider)
{
    
}
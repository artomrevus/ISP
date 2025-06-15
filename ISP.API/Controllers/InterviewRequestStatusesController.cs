using ISP.BLL.DTOs.ISP.InterviewRequestStatus;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
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
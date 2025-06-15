using ISP.BLL.DTOs.ISP.InterviewResult;
using ISP.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ResponseCache(CacheProfileName = "LongCache")]
public class InterviewResultsController(IServiceProvider serviceProvider)
    : IspController<InterviewResult, GetInterviewResultDto, AddInterviewResultDto, UpdateInterviewResultDto, InterviewResultFilterParameters>(serviceProvider)
{
    
}
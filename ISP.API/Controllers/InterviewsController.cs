using ISP.BLL.DTOs.ISP.Interview;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class InterviewsController(IServiceProvider serviceProvider)
    : IspController<Interview, GetInterviewDto, AddInterviewDto, UpdateInterviewDto, InterviewFilterParameters>(serviceProvider)
{
    
}
using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.DTOs.ISP.Interview;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InterviewService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Interview, GetInterviewDto, AddInterviewDto, UpdateInterviewDto, InterviewFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Interview, bool>> BuildFilter(InterviewFilterParameters filterParameters)
    {
        Expression<Func<Interview, bool>> filter = c => true;
        
        if (filterParameters.InterviewRequestIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.InterviewRequestIds.Contains(x.InterviewRequestId));
        }

        return filter;
    }
}
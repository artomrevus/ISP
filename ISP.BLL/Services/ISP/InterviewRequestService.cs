using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.InterviewRequest;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InterviewRequestService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<InterviewRequest, GetInterviewRequestDto, AddInterviewRequestDto, UpdateInterviewRequestDto, InterviewRequestFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<InterviewRequest, bool>> BuildFilter(InterviewRequestFilterParameters filterParameters)
    {
        Expression<Func<InterviewRequest, bool>> filter = c => true;
        
        if (filterParameters.VacancyIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.VacancyIds.Contains(x.VacancyId));
        }

        return filter;
    }

    protected override Func<IQueryable<InterviewRequest>, IOrderedQueryable<InterviewRequest>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.ApplicationDate => sortingParameters.Ascending 
                ? q => q.OrderBy(x => x.ApplicationDate) 
                : q => q.OrderByDescending(x => x.ApplicationDate),
            _ => null
        };
    }
}
using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Vacancy;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class VacancyService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Vacancy, GetVacancyDto, AddVacancyDto, UpdateVacancyDto, VacancyFilterParameters>(unitOfWork, mapper)
{
   protected override Expression<Func<Vacancy, bool>> BuildFilter(VacancyFilterParameters filterParameters)
    {
        Expression<Func<Vacancy, bool>> filter = c => true;
        
        if (filterParameters.VacancyStatusIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.VacancyStatusIds.Contains(x.VacancyStatusId));
        }
        
        if (filterParameters.EmployeePositionIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.EmployeePositionIds.Contains(x.EmployeePositionId));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.NumberContains))
        {
            filter = filter.And(
                x => x.Number.ToLower().Contains(filterParameters.NumberContains.ToLower()));
        }
        
        if (filterParameters.AppearanceDateFrom.HasValue)
        {
            filter = filter.And(
                x => x.AppearanceDate >= filterParameters.AppearanceDateFrom.Value);
        }
        
        if (filterParameters.AppearanceDateTo.HasValue)
        {
            filter = filter.And(
                x => x.AppearanceDate <= filterParameters.AppearanceDateTo.Value);
        }
        
        if (filterParameters.MonthRateFrom.HasValue)
        {
            filter = filter.And(
                x => x.MonthRate >= filterParameters.MonthRateFrom.Value);
        }
        
        if (filterParameters.MonthRateTo.HasValue)
        {
            filter = filter.And(
                x => x.MonthRate <= filterParameters.MonthRateTo.Value);
        }
        
        if (filterParameters.InterviewRequestsCountFrom.HasValue)
        {
            filter = filter.And(
                x => x.InterviewRequests.Count >= filterParameters.InterviewRequestsCountFrom.Value);
        }
        
        if (filterParameters.InterviewRequestsCountTo.HasValue)
        {
            filter = filter.And(
                x => x.InterviewRequests.Count <= filterParameters.InterviewRequestsCountTo.Value);
        }

        return filter;
    }

    protected override Func<IQueryable<Vacancy>, IOrderedQueryable<Vacancy>>? BuildSorting(
        SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.AppearanceDate => sortingParameters.Ascending 
                ? q => q.OrderBy(x => x.AppearanceDate)
                : q => q.OrderByDescending(x => x.AppearanceDate),
            SortByValues.MonthRate => sortingParameters.Ascending 
                ? q => q.OrderBy(x => x.MonthRate)
                : q => q.OrderByDescending(x => x.MonthRate),
            SortByValues.InterviewRequestsCount => sortingParameters.Ascending 
                ? q => q.OrderBy(x => x.InterviewRequests.Count)
                : q => q.OrderByDescending(x => x.InterviewRequests.Count),
            _ => null
        };
    }
}
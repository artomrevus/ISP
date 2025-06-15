using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Candidate;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Candidate, GetCandidateDto, AddCandidateDto, UpdateCandidateDto, CandidateFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Candidate, bool>> BuildFilter(CandidateFilterParameters filterParameters)
    {
        Expression<Func<Candidate, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.FirstNameContains))
        {
            filter = filter.And(x => x.FirstName.ToLower().Contains(filterParameters.FirstNameContains.ToLower()));
        }

        if (!string.IsNullOrEmpty(filterParameters.LastNameContains))
        {
            filter = filter.And(x => x.LastName.ToLower().Contains(filterParameters.LastNameContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.PhoneNumberContains))
        {
            filter = filter.And(x => x.PhoneNumber.ToLower().Contains(filterParameters.PhoneNumberContains.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.EmailContains))
        {
            filter = filter.And(x => x.Email.ToLower().Contains(filterParameters.EmailContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<Candidate>, IOrderedQueryable<Candidate>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.FirstName => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.FirstName)
                : q => q.OrderByDescending(x => x.FirstName),
            SortByValues.LastName => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.LastName)
                : q => q.OrderByDescending(x => x.LastName),
            SortByValues.PhoneNumber => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.PhoneNumber)
                : q => q.OrderByDescending(x => x.PhoneNumber),
            SortByValues.Email => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Email)
                : q => q.OrderByDescending(x => x.Email),
            _ => null
        };
    }
}
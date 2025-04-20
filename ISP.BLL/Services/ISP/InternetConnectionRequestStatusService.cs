using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.InternetConnectionRequestStatus;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InternetConnectionRequestStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<
        InternetConnectionRequestStatus,
        GetInternetConnectionRequestStatusDto,
        AddInternetConnectionRequestStatusDto,
        UpdateInternetConnectionRequestStatusDto,
        InternetConnectionRequestStatusFilterParameters
    >(unitOfWork, mapper)
{
    protected override Expression<Func<InternetConnectionRequestStatus, bool>> BuildFilter(
        InternetConnectionRequestStatusFilterParameters filterParameters)
    {
        Expression<Func<InternetConnectionRequestStatus, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.InternetConnectionRequestStatusContains))
        {
            filter = filter.And(
                x => x.InternetConnectionRequestStatusName!.ToLower()
                    .Contains(filterParameters.InternetConnectionRequestStatusContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<InternetConnectionRequestStatus>, IOrderedQueryable<InternetConnectionRequestStatus>>? BuildSorting(
        SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            // To add sorting
            _ => null
        };
    }
}
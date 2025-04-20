using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.InternetTariffStatus;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class InternetTariffStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<InternetTariffStatus, GetInternetTariffStatusDto, AddInternetTariffStatusDto, UpdateInternetTariffStatusDto, InternetTariffStatusFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<InternetTariffStatus, bool>> BuildFilter(InternetTariffStatusFilterParameters filterParameters)
    {
        Expression<Func<InternetTariffStatus, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.InternetTariffStatusContains))
        {
            filter = filter.And(
                x => x.InternetTariffStatusName!.ToLower().Contains(filterParameters.InternetTariffStatusContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<InternetTariffStatus>, IOrderedQueryable<InternetTariffStatus>>? BuildSorting(SortingParameters sortingParameters)
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
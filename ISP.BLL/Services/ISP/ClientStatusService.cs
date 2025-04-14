using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.ClientStatus;
using ISP.BLL.Extensions;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ClientStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<ClientStatus, GetClientStatusDto, AddClientStatusDto, UpdateClientStatusDto, ClientStatusFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<ClientStatus, bool>> BuildFilter(ClientStatusFilterParameters filterParameters)
    {
        Expression<Func<ClientStatus, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.ClientStatusContains))
        {
            filter = filter.And(x => x.ClientStatusName!.ToLower().Contains(filterParameters.ClientStatusContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<ClientStatus>, IOrderedQueryable<ClientStatus>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.ClientStatus => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.ClientStatusName)
                : q => q.OrderByDescending(x => x.ClientStatusName),
            _ => null
        };
    }
}
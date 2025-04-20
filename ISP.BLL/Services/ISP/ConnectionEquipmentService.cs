using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.ConnectionEquipment;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class ConnectionEquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<ConnectionEquipment, GetConnectionEquipmentDto, AddConnectionEquipmentDto, UpdateConnectionEquipmentDto, ConnectionEquipmentFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<ConnectionEquipment, bool>> BuildFilter(ConnectionEquipmentFilterParameters filterParameters)
    {
        Expression<Func<ConnectionEquipment, bool>> filter = c => true;
        
        if (filterParameters.ConnectionIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.ConnectionIds.Contains(x.ConnectionId));
        }
        
        if (filterParameters.OfficeEquipmentIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.OfficeEquipmentIds.Contains(x.OfficeEquipmentId));
        }
        
        if (filterParameters.ConnectionEquipmentAmountFrom.HasValue)
        {
            filter = filter.And(x => x.ConnectionEquipmentAmount >= filterParameters.ConnectionEquipmentAmountFrom.Value);
        }
        
        if (filterParameters.ConnectionEquipmentAmountTo.HasValue)
        {
            filter = filter.And(x => x.ConnectionEquipmentAmount <= filterParameters.ConnectionEquipmentAmountTo.Value);
        }
    
        return filter;
    }
    
    protected override Func<IQueryable<ConnectionEquipment>, IOrderedQueryable<ConnectionEquipment>>? BuildSorting(
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
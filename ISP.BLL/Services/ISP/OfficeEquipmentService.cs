using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.OfficeEquipment;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class OfficeEquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<OfficeEquipment, GetOfficeEquipmentDto, AddOfficeEquipmentDto, UpdateOfficeEquipmentDto, OfficeEquipmentFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<OfficeEquipment, bool>> BuildFilter(OfficeEquipmentFilterParameters filterParameters)
    {
        Expression<Func<OfficeEquipment, bool>> filter = c => true;
        
        if (filterParameters.OfficeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.OfficeIds.Contains(x.OfficeId));
        }
        
        if (filterParameters.EquipmentIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.EquipmentIds.Contains(x.EquipmentId));
        }
        
        if (filterParameters.OfficeEquipmentAmountFrom.HasValue)
        {
            filter = filter.And(x => x.OfficeEquipmentAmount >= filterParameters.OfficeEquipmentAmountFrom.Value);
        }
        
        if (filterParameters.OfficeEquipmentAmountTo.HasValue)
        {
            filter = filter.And(x => x.OfficeEquipmentAmount <= filterParameters.OfficeEquipmentAmountTo.Value);
        }

        return filter;
    }

    protected override Func<IQueryable<OfficeEquipment>, IOrderedQueryable<OfficeEquipment>>? BuildSorting(SortingParameters sortingParameters)
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
using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.EquipmentType;
using ISP.BLL.DTOs.ISP.Street;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class EquipmentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<EquipmentType, GetEquipmentTypeDto, AddEquipmentTypeDto, UpdateEquipmentTypeDto, EquipmentTypeFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<EquipmentType, bool>> BuildFilter(EquipmentTypeFilterParameters filterParameters)
    {
        Expression<Func<EquipmentType, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.EquipmentTypeContains))
        {
            filter = filter.And(x => x.EquipmentTypeName!.ToLower().Contains(filterParameters.EquipmentTypeContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<EquipmentType>, IOrderedQueryable<EquipmentType>>? BuildSorting(SortingParameters sortingParameters)
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
using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Equipment;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class EquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Equipment, GetEquipmentDto, AddEquipmentDto, UpdateEquipmentDto, EquipmentFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Equipment, bool>> BuildFilter(EquipmentFilterParameters filterParameters)
    {
        Expression<Func<Equipment, bool>> filter = c => true;
        
        if (filterParameters.EquipmentTypeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.EquipmentTypeIds.Contains(x.EquipmentTypeId));
        }
        
        if (filterParameters.PriceFrom.HasValue)
        {
            filter = filter.And(x => x.Price >= filterParameters.PriceFrom.Value);
        }
        
        if (filterParameters.PriceTo.HasValue)
        {
            filter = filter.And(x => x.Price <= filterParameters.PriceTo.Value);
        }
        
        if (!string.IsNullOrEmpty(filterParameters.NameContains))
        {
            filter = filter.And(x => x.Name.ToLower().Contains(filterParameters.NameContains.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<Equipment>, IOrderedQueryable<Equipment>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
             SortByValues.Name => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Name)
                : q => q.OrderByDescending(x => x.Name),
            SortByValues.Price => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Price)
                : q => q.OrderByDescending(x => x.Price),
            SortByValues.EquipmentType => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.EquipmentType.EquipmentTypeName)
                : q => q.OrderByDescending(x => x.EquipmentType.EquipmentTypeName),
            _ => null
        };
    }
}
using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.DTOs.ISP.EquipmentPlacement;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class EquipmentPlacementService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<EquipmentPlacement, GetEquipmentPlacementDto, AddEquipmentPlacementDto, UpdateEquipmentPlacementDto, EquipmentPlacementFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<EquipmentPlacement, bool>> BuildFilter(EquipmentPlacementFilterParameters filterParameters)
    {
        Expression<Func<EquipmentPlacement, bool>> filter = c => true;
        
        if (filterParameters.PurchaseEquipmentIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.PurchaseEquipmentIds.Contains(x.PurchaseEquipmentId));
        }
    
        return filter;
    }
}
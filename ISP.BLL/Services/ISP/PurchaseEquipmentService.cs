using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.DTOs.ISP.PurchaseEquipment;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class PurchaseEquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<PurchaseEquipment, GetPurchaseEquipmentDto, AddPurchaseEquipmentDto, UpdatePurchaseEquipmentDto, PurchaseEquipmentFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<PurchaseEquipment, bool>> BuildFilter(PurchaseEquipmentFilterParameters filterParameters)
    {
        Expression<Func<PurchaseEquipment, bool>> filter = c => true;
        
        if (filterParameters.PurchaseIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.PurchaseIds.Contains(x.PurchaseId));
        }
    
        return filter;
    }
}
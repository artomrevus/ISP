using AutoMapper;
using ISP.BLL.DTOs.ISP.PurchaseStatus;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class PurchaseStatusService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<PurchaseStatus, GetPurchaseStatusDto, AddPurchaseStatusDto, UpdatePurchaseStatusDto, PurchaseStatusFilterParameters>(unitOfWork, mapper)
{
   
}
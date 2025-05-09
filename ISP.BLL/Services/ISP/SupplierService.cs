using AutoMapper;
using ISP.BLL.DTOs.ISP.Candidate;
using ISP.BLL.DTOs.ISP.Interview;
using ISP.BLL.DTOs.ISP.Supplier;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Supplier, GetSupplierDto, AddSupplierDto, UpdateSupplierDto, SupplierFilterParameters>(unitOfWork, mapper)
{
    
}
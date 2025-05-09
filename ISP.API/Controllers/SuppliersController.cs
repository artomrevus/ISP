using ISP.BLL.DTOs.ISP.Candidate;
using ISP.BLL.DTOs.ISP.Supplier;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class SuppliersController(IServiceProvider serviceProvider)
    : IspController<Supplier, GetSupplierDto, AddSupplierDto, UpdateSupplierDto, SupplierFilterParameters>(serviceProvider)
{
    
}
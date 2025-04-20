using ISP.BLL.DTOs.ISP.Contract;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class ContractsController(IServiceProvider serviceProvider)
    : IspController<Contract, GetContractDto, AddContractDto, UpdateContractDto, ContractFilterParameters>(serviceProvider)
{
    
}
using ISP.BLL.DTOs.ISP.ContractStatus;
using ISP.DAL.Entities;

namespace ISP.API.Controllers;

public class ContractStatusesController(IServiceProvider serviceProvider)
    : IspController<ContractStatus, GetContractStatusDto, AddContractStatusDto, UpdateContractStatusDto, ContractStatusFilterParameters>(serviceProvider)
{
    
}
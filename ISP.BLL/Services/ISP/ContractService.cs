using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Contract;
using ISP.BLL.Extensions;
using ISP.DAL.Interfaces;
using Contract = ISP.DAL.Entities.Contract;

namespace ISP.BLL.Services.ISP;

public class ContractService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Contract, GetContractDto, AddContractDto, UpdateContractDto, ContractFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Contract, bool>> BuildFilter(ContractFilterParameters filterParameters)
    {
        Expression<Func<Contract, bool>> filter = c => true;
        
        if (filterParameters.EmployeeIds.Count > 0)
        {
            filter = filter.And(x => filterParameters.EmployeeIds.Contains(x.EmployeeId));
        }
        
        return filter;
    }

    protected override Func<IQueryable<Contract>, IOrderedQueryable<Contract>>? BuildSorting(SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.ConclusionDate => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.ConclusionDate)
                : q => q.OrderByDescending(x => x.ConclusionDate),
            _ => null
        };
    }
}
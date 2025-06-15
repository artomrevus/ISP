using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Supplier;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Supplier, GetSupplierDto, AddSupplierDto, UpdateSupplierDto, SupplierFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Supplier, bool>> BuildFilter(SupplierFilterParameters filterParameters)
    {
        Expression<Func<Supplier, bool>> filter = c => true;
        
        if (!string.IsNullOrEmpty(filterParameters.Name))
        {
            filter = filter.And(
                x => x.Name.ToLower().Contains(filterParameters.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(filterParameters.PhoneNumber))
        {
            filter = filter.And(
                x => x.PhoneNumber.ToLower().Contains(filterParameters.PhoneNumber.ToLower()));
        }
        
        if (!string.IsNullOrEmpty(filterParameters.Email))
        {
            filter = filter.And(
                x => x.Email.ToLower().Contains(filterParameters.Email.ToLower()));
        }

        return filter;
    }

    protected override Func<IQueryable<Supplier>, IOrderedQueryable<Supplier>>? BuildSorting(
        SortingParameters sortingParameters)
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
            SortByValues.PhoneNumber => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.PhoneNumber)
                : q => q.OrderByDescending(x => x.PhoneNumber),
            SortByValues.Email => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Email)
                : q => q.OrderByDescending(x => x.Email),
            _ => null
        };
    }
}
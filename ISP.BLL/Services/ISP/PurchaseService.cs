using System.Linq.Expressions;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.ISP.Purchase;
using ISP.BLL.Extensions;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.BLL.Services.ISP;

public class PurchaseService(IUnitOfWork unitOfWork, IMapper mapper)
    : IspService<Purchase, GetPurchaseDto, AddPurchaseDto, UpdatePurchaseDto, PurchaseFilterParameters>(unitOfWork, mapper)
{
    protected override Expression<Func<Purchase, bool>> BuildFilter(PurchaseFilterParameters filterParameters)
    {
        Expression<Func<Purchase, bool>> filter = c => true;

        if (filterParameters.PurchaseStatusIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.PurchaseStatusIds.Contains(x.PurchaseStatusId));
        }

        if (filterParameters.SupplierIds.Count > 0)
        {
            filter = filter.And(
                x => filterParameters.SupplierIds.Contains(x.SupplierId));
        }

        if (!string.IsNullOrEmpty(filterParameters.NumberContains))
        {
            filter = filter.And(
                x => x.Number.ToLower().Contains(filterParameters.NumberContains.ToLower()));
        }

        if (filterParameters.DateFrom.HasValue)
        {
            filter = filter.And(
                x => x.Date >= filterParameters.DateFrom.Value);
        }

        if (filterParameters.DateTo.HasValue)
        {
            filter = filter.And(
                x => x.Date <= filterParameters.DateTo.Value);
        }

        if (filterParameters.TotalPriceFrom.HasValue)
        {
            filter = filter.And(
                x => x.TotalPrice >= filterParameters.TotalPriceFrom.Value);
        }

        if (filterParameters.TotalPriceTo.HasValue)
        {
            filter = filter.And(
                x => x.TotalPrice <= filterParameters.TotalPriceTo.Value);
        }

        if (filterParameters.PurchaseEquipmentsCountFrom.HasValue)
        {
            filter = filter.And(
                x => x.PurchaseEquipments.Count >= filterParameters.PurchaseEquipmentsCountFrom.Value);
        }

        if (filterParameters.PurchaseEquipmentsCountTo.HasValue)
        {
            filter = filter.And(
                x => x.PurchaseEquipments.Count <= filterParameters.PurchaseEquipmentsCountTo.Value);
        }

        return filter;
    }

    protected override Func<IQueryable<Purchase>, IOrderedQueryable<Purchase>>? BuildSorting(
        SortingParameters sortingParameters)
    {
        if (string.IsNullOrEmpty(sortingParameters.SortBy))
        {
            return null;
        }

        return sortingParameters.SortBy.ToLower() switch
        {
            SortByValues.PurchaseDate => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.Date)
                : q => q.OrderByDescending(x => x.Date),
            SortByValues.PurchaseTotalPrice => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.TotalPrice)
                : q => q.OrderByDescending(x => x.TotalPrice),
            SortByValues.PurchaseEquipmentsCount => sortingParameters.Ascending
                ? q => q.OrderBy(x => x.PurchaseEquipments.Sum(pe => pe.PurchaseEquipmentAmount))
                : q => q.OrderByDescending(x => x.PurchaseEquipments.Sum(pe => pe.PurchaseEquipmentAmount)),
            _ => null
        };
    }
}
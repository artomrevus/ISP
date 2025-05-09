using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Purchase;

public class PurchaseFilterParameters
{
    public List<int> PurchaseStatusIds { get; set; } = [];
    
    public List<int> SupplierIds { get; set; } = [];
    
    public string? NumberContains { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? DateFrom { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? DateTo { get; set; }
    
    public decimal? TotalPriceFrom { get; set; }
    
    public decimal? TotalPriceTo { get; set; }
    
    public int? PurchaseEquipmentsCountFrom { get; set; }
    
    public int? PurchaseEquipmentsCountTo { get; set; }
}
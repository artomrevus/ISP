using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.ConnectionTariff;

public class ConnectionTariffFilterParameters
{
    public string? NameContains { get; set; }
    
    public decimal? PriceFrom { get; set; }
    
    public decimal? PriceTo { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? StartDateFrom { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? StartDateTo { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? EndDateFrom { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? EndDateTo { get; set; }
}
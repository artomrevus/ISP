using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Connection;

public class ConnectionFilterParameters
{
    public List<int> ConnectionTariffIds { get; set; } = [];
    
    public List<int> InternetConnectionRequestIds { get; set; } = [];
    
    public List<int> EmployeeIds { get; set; } = [];
    
    public List<int> OfficeIds { get; set; } = [];
    
    public List<int> CityIds { get; set; } = [];
    
    public List<int> ClientIds { get; set; } = [];
    
    public List<int> InternetTariffIds { get; set; } = [];
    
    public List<int> InternetConnectionRequestStatusIds { get; set; } = [];
    
    public List<int> ClientStatusIds { get; set; } = [];
    
    public List<int> LocationIds { get; set; } = [];
    
    public List<int> LocationTypeIds { get; set; } = [];
    
    public List<int> HouseIds { get; set; } = [];
    
    public List<int> StreetIds { get; set; } = [];
    
    public List<int> InternetTariffStatusIds { get; set; } = [];
    
    public decimal? TotalPriceFrom { get; set; }
    
    public decimal? TotalPriceTo { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? ConnectionDateFrom { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? ConnectionDateTo { get; set; }
}
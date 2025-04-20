using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.InternetConnectionRequest;

public class InternetConnectionRequestFilterParameters
{
    public List<int> ClientIds { get; set; } = [];
    
    public List<int> InternetTariffIds { get; set; } = [];
    
    public List<int> InternetConnectionRequestStatusIds { get; set; } = [];
    
    public List<int> ClientStatusIds { get; set; } = [];
    
    public List<int> LocationIds { get; set; } = [];
    
    public List<int> LocationTypeIds { get; set; } = [];
    
    public List<int> HouseIds { get; set; } = [];
    
    public List<int> StreetIds { get; set; } = [];
    
    public List<int> CityIds { get; set; } = [];
    
    public List<int> InternetTariffStatusIds { get; set; } = [];
    
    public string? NumberContains { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? RequestDateFrom { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? RequestDateTo { get; set; }
}
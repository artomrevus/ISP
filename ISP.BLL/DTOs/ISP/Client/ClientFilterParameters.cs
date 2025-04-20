using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Client;

public class ClientFilterParameters
{
    public List<int> ClientStatusIds { get; set; } = [];
    
    public List<int> LocationIds { get; set; } = [];
    
    public List<int> LocationTypeIds { get; set; } = [];
    
    public List<int> HouseIds { get; set; } = [];
    
    public List<int> StreetIds { get; set; } = [];
    
    public List<int> CityIds { get; set; } = [];
    
    public string? FirstNameContains { get; set; }
    
    public string? LastNameContains { get; set; }
    
    public string? PhoneNumberContains { get; set; }
    
    public string? EmailContains { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? RegistrationDateFrom { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? RegistrationDateTo { get; set; }
}
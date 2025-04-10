using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.Filtering;

public class ClientFilterParameters
{
    public int? ClientStatusId { get; set; }
    
    public string? StreetContains { get; set; }
    
    public string? CityContains { get; set; }
    
    public string? FirstNameContains { get; set; }
    
    public string? LastNameContains { get; set; }
    
    public string? PhoneNumberContains { get; set; }
    
    public string? EmailContains { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? RegistrationDateFrom { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? RegistrationDateTo { get; set; }
}
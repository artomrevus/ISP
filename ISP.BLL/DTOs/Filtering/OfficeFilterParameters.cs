namespace ISP.BLL.DTOs.Filtering;

public class OfficeFilterParameters
{
    public int? CityId { get; set; }
    
    public string? AddressContains { get; set; }
    
    public string? PhoneNumberContains { get; set; }
    
    public string? EmailContains { get; set; }
    
    public string? CityContains { get; set; }
}
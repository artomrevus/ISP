namespace ISP.BLL.DTOs.ISP.Office;

public class OfficeFilterParameters
{
    public List<int> CityIds { get; set; } = [];
    
    public string? AddressContains { get; set; }
    
    public string? PhoneNumberContains { get; set; }
    
    public string? EmailContains { get; set; }
}
namespace ISP.BLL.DTOs.ISP.Street;

public class StreetFilterParameters
{
    public int? CityId { get; set; }
    
    public string? StreetContains { get; set; }
    
    public string? CityContains { get; set; }
}
namespace ISP.BLL.DTOs.Filtering;

public class LocationFilterParameters
{
    public int? LocationTypeId { get; set; }
    
    public int? HouseId { get; set; }
    
    public int? StreetId { get; set; }
    
    public int? CityId { get; set; }
    
    public string? LocationTypeContains { get; set; }
    
    public string? HouseNumberContains { get; set; }
    
    public string? StreetContains { get; set; }
    
    public string? CityContains { get; set; }
}
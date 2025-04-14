namespace ISP.BLL.DTOs.Filtering;

public class HouseFilterParameters
{
    public int? StreetId { get; set; }
    
    public int? CityId { get; set; }
    
    public string? HouseNumberContains { get; set; }
    
    public string? StreetContains { get; set; }
    
    public string? CityContains { get; set; }
}
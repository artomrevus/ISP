namespace ISP.BLL.DTOs.ISP.House;

public class HouseFilterParameters
{
    public List<int> StreetIds { get; set; } = [];
    
    public List<int> CityIds { get; set; } = [];
    
    public string? HouseNumberContains { get; set; }
}
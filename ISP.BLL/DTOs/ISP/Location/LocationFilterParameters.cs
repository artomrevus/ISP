namespace ISP.BLL.DTOs.ISP.Location;

public class LocationFilterParameters
{
    public List<int> LocationTypeIds { get; set; } = [];
    
    public List<int> HouseIds { get; set; } = [];
    
    public List<int> StreetIds { get; set; } = [];
    
    public List<int> CityIds { get; set; } = [];
}
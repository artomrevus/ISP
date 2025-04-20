namespace ISP.BLL.DTOs.ISP.Street;

public class StreetFilterParameters
{
    public List<int> CityIds { get; set; } = [];
    
    public string? StreetContains { get; set; }
}
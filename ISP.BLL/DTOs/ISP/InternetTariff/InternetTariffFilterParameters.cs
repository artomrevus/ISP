namespace ISP.BLL.DTOs.ISP.InternetTariff;

public class InternetTariffFilterParameters
{
    public List<int> LocationTypeIds { get; set; } = [];

    public List<int> InternetTariffStatusIds { get; set; } = [];
    
    public decimal? PriceFrom { get; set; }
    
    public decimal? PriceTo { get; set; }
    
    public int? InternetSpeedMbitsFrom { get; set; }
    
    public int? InternetSpeedMbitsTo { get; set; }
    
    public string? NameContains { get; set; }
}
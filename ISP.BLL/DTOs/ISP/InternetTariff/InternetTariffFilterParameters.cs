namespace ISP.BLL.DTOs.ISP.InternetTariff;

public class InternetTariffFilterParameters
{
    public int? LocationTypeId { get; set; }
    
    public int? InternetTariffStatusId { get; set; }
    
    public decimal? PriceFrom { get; set; }
    
    public decimal? PriceTo { get; set; }
    
    public int? InternetSpeedMbitsFrom { get; set; }
    
    public int? InternetSpeedMbitsTo { get; set; }
    
    public string? NameContains { get; set; }
    
    public string? LocationTypeContains { get; set; }
    
    public string? InternetTariffStatusContains { get; set; }
}
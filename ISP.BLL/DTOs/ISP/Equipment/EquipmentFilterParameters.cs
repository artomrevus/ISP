namespace ISP.BLL.DTOs.ISP.Equipment;

public class EquipmentFilterParameters
{
    public List<int> EquipmentTypeIds { get; set; } = [];
    
    public decimal? PriceFrom { get; set; }
    
    public decimal? PriceTo { get; set; }
    
    public string? NameContains { get; set; }
}
namespace ISP.BLL.DTOs.ISP.OfficeEquipment;

public class OfficeEquipmentFilterParameters
{
    public List<int> OfficeIds { get; set; } = [];
    
    public List<int> EquipmentIds { get; set; } = [];
    
    public int? OfficeEquipmentAmountFrom { get; set; }
    
    public int? OfficeEquipmentAmountTo { get; set; }
}
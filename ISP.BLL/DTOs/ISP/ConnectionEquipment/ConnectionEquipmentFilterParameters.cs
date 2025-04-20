namespace ISP.BLL.DTOs.ISP.ConnectionEquipment;

public class ConnectionEquipmentFilterParameters
{
    public List<int> ConnectionIds { get; set; } = [];
    
    public List<int> OfficeEquipmentIds { get; set; } = [];
    
    public int? ConnectionEquipmentAmountFrom { get; set; }
    
    public int? ConnectionEquipmentAmountTo { get; set; }
}
namespace ISP.BLL.DTOs.ISP.PurchaseEquipment;

public class GetPurchaseEquipmentDto
{
    public int Id { get; set; }

    public int PurchaseId { get; set; }

    public int EquipmentId { get; set; }

    public int PurchaseEquipmentAmount { get; set; }

    public decimal Price { get; set; }
}
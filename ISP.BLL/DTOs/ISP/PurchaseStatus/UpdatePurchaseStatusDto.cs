namespace ISP.BLL.DTOs.ISP.PurchaseStatus;

public class UpdatePurchaseStatusDto
{
    public int Id { get; set; }

    public string PurchaseStatusName { get; set; }  = default!;
}
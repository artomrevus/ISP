using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class PurchaseEquipment : IEntity
{
    public int Id { get; set; }

    public int PurchaseId { get; set; }

    public int EquipmentId { get; set; }

    public string PurchaseEquipmentAmount { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public Equipment Equipment { get; set; } = null!;

    public ICollection<EquipmentPlacement> EquipmentPlacements { get; set; } = new List<EquipmentPlacement>();

    public Purchase Purchase { get; set; } = null!;
}

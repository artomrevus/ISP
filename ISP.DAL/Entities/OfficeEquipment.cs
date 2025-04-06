using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class OfficeEquipment : IEntity
{
    public int Id { get; set; }

    public int OfficeId { get; set; }

    public int EquipmentId { get; set; }

    public int OfficeEquipmentAmount { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<ConnectionEquipment> ConnectionEquipments { get; set; } = new List<ConnectionEquipment>();

    public Equipment Equipment { get; set; } = null!;

    public ICollection<EquipmentPlacement> EquipmentPlacements { get; set; } = new List<EquipmentPlacement>();

    public Office Office { get; set; } = null!;
}

using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class ConnectionEquipment : IEntity
{
    public int Id { get; set; }

    public int ConnectionId { get; set; }

    public int OfficeEquipmentId { get; set; }

    public int ConnectionEquipmentAmount { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public Connection Connection { get; set; } = null!;

    public OfficeEquipment OfficeEquipment { get; set; } = null!;
}

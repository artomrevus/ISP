using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Connection : IEntity
{
    public int Id { get; set; }

    public int InternetConnectionRequestId { get; set; }

    public int ConnectionTariffId { get; set; }

    public int EmployeeId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateOnly ConnectionDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<ConnectionEquipment> ConnectionEquipments { get; set; } = new List<ConnectionEquipment>();

    public ConnectionTariff ConnectionTariff { get; set; } = null!;

    public Employee Employee { get; set; } = null!;

    public InternetConnectionRequest InternetConnectionRequest { get; set; } = null!;
}

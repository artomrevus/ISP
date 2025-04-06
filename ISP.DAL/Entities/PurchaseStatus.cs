using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class PurchaseStatus : IEntity
{
    public int Id { get; set; }

    public string? PurchaseStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}

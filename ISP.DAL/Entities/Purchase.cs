using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Purchase : IEntity
{
    public int Id { get; set; }

    public int PurchaseStatusId { get; set; }

    public int SupplierId { get; set; }

    public int EmployeeId { get; set; }

    public string Number { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public DateOnly Date { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public Employee Employee { get; set; } = null!;

    public ICollection<PurchaseEquipment> PurchaseEquipments { get; set; } = new List<PurchaseEquipment>();

    public PurchaseStatus PurchaseStatus { get; set; } = null!;

    public Supplier Supplier { get; set; } = null!;
}

using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Supplier : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}

using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Street : IEntity
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string StreetName { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public City City { get; set; } = null!;

    public ICollection<House> Houses { get; set; } = new List<House>();
}

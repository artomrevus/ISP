using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class LocationType : IEntity
{
    public int Id { get; set; }

    public string? LocationTypeName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<InternetTariff> InternetTariffs { get; set; } = new List<InternetTariff>();

    public ICollection<Location> Locations { get; set; } = new List<Location>();
}

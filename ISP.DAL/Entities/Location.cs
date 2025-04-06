using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Location : IEntity
{
    public int Id { get; set; }

    public int LocationTypeId { get; set; }

    public int HouseId { get; set; }

    public int? ApartmentNumber { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Client> Clients { get; set; } = new List<Client>();

    public House House { get; set; } = null!;

    public LocationType LocationType { get; set; } = null!;
}

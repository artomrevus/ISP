using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class House : IEntity
{
    public int Id { get; set; }

    public int StreetId { get; set; }

    public string? HouseNumber { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Location> Locations { get; set; } = new List<Location>();

    public Street Street { get; set; } = null!;
}

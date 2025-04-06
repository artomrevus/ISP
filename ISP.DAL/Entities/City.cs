using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class City : IEntity
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Office> Offices { get; set; } = new List<Office>();

    public ICollection<Street> Streets { get; set; } = new List<Street>();
}

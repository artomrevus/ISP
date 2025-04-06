using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class InternetTariffStatus : IEntity
{
    public int Id { get; set; }

    public string? InternetTariffStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<InternetTariff> InternetTariffs { get; set; } = new List<InternetTariff>();
}

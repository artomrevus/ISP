using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class EquipmentType : IEntity
{
    public int Id { get; set; }

    public string? EquipmentTypeName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}

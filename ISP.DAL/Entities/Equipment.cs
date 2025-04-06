using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Equipment : IEntity
{
    public int Id { get; set; }

    public int EquipmentTypeId { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public EquipmentType EquipmentType { get; set; } = null!;

    public ICollection<OfficeEquipment> OfficeEquipments { get; set; } = new List<OfficeEquipment>();

    public ICollection<PurchaseEquipment> PurchaseEquipments { get; set; } = new List<PurchaseEquipment>();
}

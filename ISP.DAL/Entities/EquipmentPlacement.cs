using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class EquipmentPlacement : IEntity
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int PurchaseEquipmentId { get; set; }

    public int OfficeEquipmentId { get; set; }

    public string EquipmentPlacementAmount { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public Employee Employee { get; set; } = null!;

    public OfficeEquipment OfficeEquipment { get; set; } = null!;

    public PurchaseEquipment PurchaseEquipment { get; set; } = null!;
}

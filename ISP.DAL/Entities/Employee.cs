using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }

    public int EmployeePositionId { get; set; }

    public int EmployeeStatusId { get; set; }

    public int OfficeId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Connection> Connections { get; set; } = new List<Connection>();

    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public EmployeePosition EmployeePosition { get; set; } = null!;

    public EmployeeStatus EmployeeStatus { get; set; } = null!;

    public ICollection<EquipmentPlacement> EquipmentPlacements { get; set; } = new List<EquipmentPlacement>();

    public Office Office { get; set; } = null!;

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}

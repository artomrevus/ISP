using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class ContractStatus : IEntity
{
    public int Id { get; set; }

    public string? ContractStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

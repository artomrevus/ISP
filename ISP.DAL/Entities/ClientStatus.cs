using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class ClientStatus : IEntity
{
    public int Id { get; set; }

    public string? ClientStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Client> Clients { get; set; } = new List<Client>();
}

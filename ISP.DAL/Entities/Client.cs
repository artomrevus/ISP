using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Client : IEntity
{
    public int Id { get; set; }

    public int ClientStatusId { get; set; }

    public int LocationId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly RegistrationDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ClientStatus ClientStatus { get; set; } = null!;

    public ICollection<InternetConnectionRequest> InternetConnectionRequests { get; set; } = new List<InternetConnectionRequest>();

    public Location Location { get; set; } = null!;
}

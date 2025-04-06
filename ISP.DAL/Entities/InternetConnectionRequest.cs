using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class InternetConnectionRequest : IEntity
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int InternetTariffId { get; set; }

    public int InternetConnectionRequestStatusId { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly RequestDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public Client Client { get; set; } = null!;

    public Connection? Connection { get; set; }

    public InternetConnectionRequestStatus InternetConnectionRequestStatus { get; set; } = null!;

    public InternetTariff InternetTariff { get; set; } = null!;
}

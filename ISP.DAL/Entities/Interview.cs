using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Interview : IEntity
{
    public int Id { get; set; }

    public int InterviewRequestId { get; set; }

    public int InterviewResultId { get; set; }

    public DateOnly Date { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public Contract? Contract { get; set; }

    public InterviewRequest InterviewRequest { get; set; } = null!;

    public InterviewResult InterviewResult { get; set; } = null!;
}

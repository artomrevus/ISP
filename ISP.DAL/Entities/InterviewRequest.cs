using System;
using System.Collections.Generic;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class InterviewRequest : IEntity
{
    public int Id { get; set; }

    public int VacancyId { get; set; }

    public int CandidateId { get; set; }

    public int InterviewRequestStatusId { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly ApplicationDate { get; set; }

    public DateOnly? ConsiderationDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public Candidate Candidate { get; set; } = null!;

    public Interview? Interview { get; set; }

    public InterviewRequestStatus InterviewRequestStatus { get; set; } = null!;

    public Vacancy Vacancy { get; set; } = null!;
}

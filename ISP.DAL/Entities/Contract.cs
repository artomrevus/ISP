using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Contract : IEntity
{
    public int Id { get; set; }

    public int ContractStatusId { get; set; }

    public int EmployeeId { get; set; }
    
    public int InterviewId { get; set; }

    public string Number { get; set; } = null!;

    public decimal MonthRate { get; set; }

    public DateOnly ConclusionDate { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ContractStatus ContractStatus { get; set; } = null!;

    public Employee Employee { get; set; } = null!;

    public Interview Interview { get; set; } = null!;
}

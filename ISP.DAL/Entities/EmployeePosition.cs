using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class EmployeePosition : IEntity
{
    public int Id { get; set; }

    public string? EmployeePositionName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}

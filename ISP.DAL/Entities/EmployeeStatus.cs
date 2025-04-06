using System;
using System.Collections.Generic;
using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class EmployeeStatus : IEntity
{
    public int Id { get; set; }

    public string? EmployeeStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

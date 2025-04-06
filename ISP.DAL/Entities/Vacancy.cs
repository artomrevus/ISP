using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Vacancy : IEntity
{
    public int Id { get; set; }

    public int VacancyStatusId { get; set; }

    public int EmployeePositionId { get; set; }

    public decimal MonthRate { get; set; }

    public string Description { get; set; } = null!;

    public string Number { get; set; } = null!;

    public DateOnly AppearanceDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public EmployeePosition EmployeePosition { get; set; } = null!;

    public ICollection<InterviewRequest> InterviewRequests { get; set; } = new List<InterviewRequest>();

    public VacancyStatus VacancyStatus { get; set; } = null!;
}

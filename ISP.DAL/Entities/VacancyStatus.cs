using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class VacancyStatus : IEntity
{
    public int Id { get; set; }

    public string? VacancyStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}

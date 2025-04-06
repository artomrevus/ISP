using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class InterviewResult : IEntity
{
    public int Id { get; set; }

    public string? InterviewResultName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
}

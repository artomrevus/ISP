using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class InterviewRequestStatus : IEntity
{
    public int Id { get; set; }

    public string? InterviewRequestStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<InterviewRequest> InterviewRequests { get; set; } = new List<InterviewRequest>();
}

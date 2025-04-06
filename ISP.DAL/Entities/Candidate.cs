using ISP.DAL.Interfaces;

namespace ISP.DAL.Entities;

public class Candidate : IEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<InterviewRequest> InterviewRequests { get; set; } = new List<InterviewRequest>();
}

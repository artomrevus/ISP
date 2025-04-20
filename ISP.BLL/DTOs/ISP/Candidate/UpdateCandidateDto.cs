namespace ISP.BLL.DTOs.ISP.Candidate;

public class UpdateCandidateDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string Email { get; set; } = default!;
}
namespace ISP.BLL.DTOs.ISP.Client;

public class AddClientDto
{
    public int ClientStatusId { get; set; }

    public int LocationId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public DateOnly RegistrationDate { get; set; }
}
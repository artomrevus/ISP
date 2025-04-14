namespace ISP.BLL.DTOs.ISP.Office;

public class AddOfficeDto
{
    public int CityId { get; set; }

    public string Address { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string Email { get; set; } = default!;
}
namespace ISP.BLL.DTOs.ISP.House;

public class UpdateHouseDto
{
    public int Id { get; set; }

    public int StreetId { get; set; }

    public string HouseNumber { get; set; } = default!;
}
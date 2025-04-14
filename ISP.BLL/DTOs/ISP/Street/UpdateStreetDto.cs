namespace ISP.BLL.DTOs.ISP.Street;

public class UpdateStreetDto
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string StreetName { get; set; } = default!;
}
namespace ISP.BLL.DTOs.ISP.Street;

public class GetStreetDto
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string StreetName { get; set; } = default!;
}
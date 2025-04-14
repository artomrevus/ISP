namespace ISP.BLL.DTOs.ISP.Street;

public class AddStreetDto
{
    public int CityId { get; set; }

    public string StreetName { get; set; } = default!;
}
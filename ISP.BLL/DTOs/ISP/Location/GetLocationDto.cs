namespace ISP.BLL.DTOs.ISP.Location;

public class GetLocationDto
{
    public int Id { get; set; }

    public int LocationTypeId { get; set; }

    public int HouseId { get; set; }

    public int? ApartmentNumber { get; set; }
}
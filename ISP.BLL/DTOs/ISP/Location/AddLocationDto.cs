namespace ISP.BLL.DTOs.ISP.Location;

public class AddLocationDto
{
    public int LocationTypeId { get; set; }

    public int HouseId { get; set; }

    public int? ApartmentNumber { get; set; }
}
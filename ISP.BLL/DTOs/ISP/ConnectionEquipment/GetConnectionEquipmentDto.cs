namespace ISP.BLL.DTOs.ISP.ConnectionEquipment;

public class GetConnectionEquipmentDto
{
    public int Id { get; set; }

    public int ConnectionId { get; set; }

    public int OfficeEquipmentId { get; set; }

    public int ConnectionEquipmentAmount { get; set; }
}
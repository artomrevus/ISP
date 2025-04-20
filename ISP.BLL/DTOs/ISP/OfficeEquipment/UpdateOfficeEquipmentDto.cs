namespace ISP.BLL.DTOs.ISP.OfficeEquipment;

public class UpdateOfficeEquipmentDto
{
    public int Id { get; set; }

    public int OfficeId { get; set; }

    public int EquipmentId { get; set; }

    public int OfficeEquipmentAmount { get; set; }
}
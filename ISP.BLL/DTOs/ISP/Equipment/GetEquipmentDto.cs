namespace ISP.BLL.DTOs.ISP.Equipment;

public class GetEquipmentDto
{
    public int Id { get; set; }

    public int EquipmentTypeId { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = default!;
}
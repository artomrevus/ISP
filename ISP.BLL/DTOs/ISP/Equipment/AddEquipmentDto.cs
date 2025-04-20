namespace ISP.BLL.DTOs.ISP.Equipment;

public class AddEquipmentDto
{
    public int EquipmentTypeId { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = default!;
}
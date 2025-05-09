namespace ISP.BLL.DTOs.ISP.Supplier;

public class UpdateSupplierDto
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string Email { get; set; } = default!;
}
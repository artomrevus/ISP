namespace ISP.BLL.DTOs.ISP.InternetTariff;

public class UpdateInternetTariffDto
{
    public int Id { get; set; }

    public int InternetTariffStatusId { get; set; }

    public int LocationTypeId { get; set; }

    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public int InternetSpeedMbits { get; set; }

    public string Description { get; set; } = default!;
}
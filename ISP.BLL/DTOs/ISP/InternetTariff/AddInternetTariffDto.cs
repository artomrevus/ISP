namespace ISP.BLL.DTOs.ISP.InternetTariff;

public class AddInternetTariffDto
{
    public int InternetTariffStatusId { get; set; }

    public int LocationTypeId { get; set; }

    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public int InternetSpeedMbits { get; set; }

    public string Description { get; set; } = default!;
}
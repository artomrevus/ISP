using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.InternetConnectionRequest;

public class UpdateInternetConnectionRequestDto
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int InternetTariffId { get; set; }

    public int InternetConnectionRequestStatusId { get; set; }

    public string Number { get; set; } = default!;

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly RequestDate { get; set; }
}
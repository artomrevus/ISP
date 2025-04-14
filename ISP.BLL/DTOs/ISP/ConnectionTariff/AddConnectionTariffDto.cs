using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.ConnectionTariff;

public class AddConnectionTariffDto
{
    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly StartDate { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly EndDate { get; set; }
}
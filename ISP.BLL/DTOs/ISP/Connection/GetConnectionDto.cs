using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Connection;

public class GetConnectionDto
{
    public int Id { get; set; }

    public int InternetConnectionRequestId { get; set; }

    public int ConnectionTariffId { get; set; }

    public int EmployeeId { get; set; }

    public decimal TotalPrice { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly ConnectionDate { get; set; }
}
using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Purchase;

public class UpdatePurchaseDto
{
    public int Id { get; set; }

    public int PurchaseStatusId { get; set; }

    public int SupplierId { get; set; }

    public int EmployeeId { get; set; }

    public string Number { get; set; } = default!;

    public decimal TotalPrice { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly Date { get; set; }
}
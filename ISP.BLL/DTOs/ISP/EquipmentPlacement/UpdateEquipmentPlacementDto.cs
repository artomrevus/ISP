using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.EquipmentPlacement;

public class UpdateEquipmentPlacementDto
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int PurchaseEquipmentId { get; set; }

    public int OfficeEquipmentId { get; set; }

    public int EquipmentPlacementAmount { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly Date { get; set; }
}
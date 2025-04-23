using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Vacancy;

public class AddVacancyDto
{
    public int VacancyStatusId { get; set; }

    public int EmployeePositionId { get; set; }

    public decimal MonthRate { get; set; }

    public string Description { get; set; } = default!;

    public string Number { get; set; } = default!;
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly AppearanceDate { get; set; }
}
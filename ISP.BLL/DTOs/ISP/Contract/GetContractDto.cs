using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Contract;

public class GetContractDto
{
    public int Id { get; set; }

    public int ContractStatusId { get; set; }

    public int EmployeeId { get; set; }
    
    public int InterviewId { get; set; }

    public string Number { get; set; } = default!;

    public decimal MonthRate { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly ConclusionDate { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly StartDate { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly EndDate { get; set; }
}
using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Vacancy;

public class VacancyFilterParameters
{
    public List<int> VacancyStatusIds { get; set; } = [];
    
    public List<int> EmployeePositionIds { get; set; } = [];
    
    public string? NumberContains { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? AppearanceDateFrom { get; set; }
    
    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? AppearanceDateTo { get; set; }
    
    public decimal? MonthRateFrom { get; set; }
    
    public decimal? MonthRateTo { get; set; }
    
    public int? InterviewRequestsCountFrom { get; set; }
    
    public int? InterviewRequestsCountTo { get; set; }
}
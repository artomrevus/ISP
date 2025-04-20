using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.Interview;

public class GetInterviewDto
{
    public int Id { get; set; }

    public int InterviewRequestId { get; set; }

    public int InterviewResultId { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly Date { get; set; }
}
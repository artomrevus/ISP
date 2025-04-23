using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BLL.DTOs.ISP.InterviewRequest;

public class AddInterviewRequestDto
{
    public int VacancyId { get; set; }

    public int CandidateId { get; set; }

    public int InterviewRequestStatusId { get; set; }

    public string Number { get; set; } = default!;

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly ApplicationDate { get; set; }

    [ModelBinder(BinderType = typeof(DateOnlyModelBinder))]
    public DateOnly? ConsiderationDate { get; set; }
}
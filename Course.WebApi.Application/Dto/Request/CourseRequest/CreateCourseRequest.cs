namespace OnlineCourse.WebApi.Application.Dto.Request.CourseRequest;

public class CreateCourseRequest
{
    public string Name { get; set; } = string.Empty;
    public string Decsription { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
}

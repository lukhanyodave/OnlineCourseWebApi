
namespace OnlineCourse.WebApi.Application.Dto.Request.UserRequest;

public class UpdateUserRequest
{
    public DateTime? last_updated_date { get; set; }
    public string? last_updated_by { get; set; } = string.Empty;
    public Guid Id { get; set; } 
    public List<Guid>? Courses { get; set; }
    public UpdateUserRequest()
    {
        Courses = new List<Guid>();   
    }
}

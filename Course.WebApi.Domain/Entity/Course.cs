
namespace OnlineCourse.WebApi.Domain.Entity;

public class Course :BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

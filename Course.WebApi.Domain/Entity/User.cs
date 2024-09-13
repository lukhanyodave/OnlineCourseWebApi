

namespace OnlineCourse.WebApi.Domain.Entity;

public class User :BaseModel
{
    public required string  FullName { get; set; } = string.Empty;
    public required string UserName { get; set; } = string.Empty;
    public virtual ICollection<UserCourse>? Courses { get; set; } 
}



namespace OnlineCourse.WebApi.Domain.Entity;

public class UserCourse :BaseModel
{
  
    public Guid courseId {  get; set; }
    public Guid UserId { get; set; }
}


namespace OnlineCourse.WebApi.Domain.Entity;

public class BaseModel 
{
   public required Guid Id { get; set; }
   public required DateTime CreatedDate { get; set; }
   public required string CreatedBy { get; set; }
   public DateTime? last_updated_date { get; set; }
   public string last_updated_by { get; set; } = string .Empty; 
}

using OnlineCourse.WebApi.Application.Dto.Request.CourseRequest;
using OnlineCourse.WebApi.Domain.Entity;
namespace OnlineCourse.WebApi.Application.Abstractions;

public interface ICourseRepository
{
    Task<Course> CreateCourse(CreateCourseRequest createCourseRequest);
    Task UpdateCourse(UpdateCourseRequest updateCourseRequest);
    Task DeleteCourse(Guid id); 
    Task<List<Course>> GetAll();
}

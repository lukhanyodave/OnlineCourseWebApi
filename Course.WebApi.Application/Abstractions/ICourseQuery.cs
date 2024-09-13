using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Abstractions;

public interface ICourseQuery
{

    ValueTask<IEnumerable<Course>> GetAll();
    ValueTask<Course> GetById(Guid id);

}
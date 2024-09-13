using Microsoft.EntityFrameworkCore;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Domain.Entity;
using OnlineCourse.WebApi.Infrastructure.Data;

namespace OnlineCourse.WebApi.Infrastructure.Queries;

public class CourseQuery : ICourseQuery
{
    private readonly CourseDbContext _context;
    public CourseQuery(CourseDbContext context) => _context = context;
    public ValueTask<IEnumerable<Course>> GetAll()
    {
        try
        {
            var query = _context.Courses.AsNoTracking()
                                       .ToList();
            if (query is not null)
                return new ValueTask<IEnumerable<Course>>(query);
            else return new ValueTask<IEnumerable<Course>>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public ValueTask<Course> GetById(Guid id)
    {
        try
        {
            var query = _context.Courses.AsNoTracking()
           .FirstOrDefault(p => p.Id == id);
            if (query is not null)
                return new ValueTask<Course>(query);
            else return new ValueTask<Course>();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

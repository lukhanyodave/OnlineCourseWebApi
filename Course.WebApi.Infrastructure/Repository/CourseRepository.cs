
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Dto.Request.CourseRequest;
using OnlineCourse.WebApi.Application.Dto.Request.UserRequest;
using OnlineCourse.WebApi.Domain.Entity;
using OnlineCourse.WebApi.Infrastructure.Data;

namespace OnlineCourse.WebApi.Infrastructure.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly CourseDbContext _context;
    public CourseRepository(CourseDbContext context) => _context = context;
    public async  Task<Course> CreateCourse(CreateCourseRequest createCourseRequest)
    {
        // Check if user already exists in DB
        var existing = await _context.Courses.AsNoTracking()
              .FirstOrDefaultAsync(p => p.Name == createCourseRequest.Name);
        try
        {

            if (existing is null)
            {
                var course = new Course()
                {
                    Id = Guid.NewGuid(),
                    Name = createCourseRequest.Name,
                    Description = createCourseRequest.Decsription,
                    CreatedDate = DateTime.Now,
                    CreatedBy = createCourseRequest.CreatedBy
                  
                };

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                // Format the response
                course = await _context.
                     Courses.Where(u => u.Id == course.Id)
                    .FirstOrDefaultAsync();
                return course;
            }
            else
                return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async  Task DeleteCourse(Guid id)
    {
        // Check if user already exists in DB
        var existing = await _context.Courses.AsNoTracking()
              .FirstOrDefaultAsync(p => p.Id == id);
        if(existing is not null)
        {
            _context.Remove(existing);
            await _context.SaveChangesAsync();
        }
         
    }

    public async  Task<List<Course>> GetAll()
    {
        try
        {
            var existing = await _context.Courses.AsNoTracking().ToListAsync();
            return existing;
        }
        catch (Exception)
        {
            throw;
        }   
    }

    public Task UpdateCourse(UpdateCourseRequest updateCourseRequest)
    {
        throw new NotImplementedException();
    }
}

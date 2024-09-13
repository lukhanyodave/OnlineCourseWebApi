using Microsoft.EntityFrameworkCore;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Dto.Request.UserRequest;
using OnlineCourse.WebApi.Domain.Entity;
using OnlineCourse.WebApi.Infrastructure.Data;

namespace OnlineCourse.WebApi.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly CourseDbContext _context;
    public UserRepository(CourseDbContext context) => _context = context;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createUserRequest"></param>
    /// <returns></returns>
    public async Task<User> Create(CreateUserRequest createUserRequest)
    {

        // Check if user already exists in DB
        var existing = await _context.Users.AsNoTracking()
              .FirstOrDefaultAsync(p => p.UserName == createUserRequest.UserName);
        try
        {

            if (existing is null)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = createUserRequest.UserName,
                    FullName = createUserRequest.FullName,
                    CreatedDate = DateTime.Now,
                    CreatedBy = createUserRequest.FullName,
                    Courses = new List<UserCourse>(),
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                // Format the response
                user = await _context.
                     Users.Where(u => u.Id == user.Id)
                    .Include(u => u.Courses)
                    .FirstOrDefaultAsync();
                return user;
            }
            else
                return null;
        }
        catch (Exception)
        {
            throw;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async  Task Delete(Guid id)
    {
        // Check if user already exists in DB
        var existing = await _context.Users.AsNoTracking()
              .FirstOrDefaultAsync(p => p.Id == id);
        try
        {
           
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<User> GetById(Guid id)
    {
        try
        {
            // Check if user already exists in DB
            var existing = await _context.Users.AsNoTracking()
                  .FirstOrDefaultAsync(p => p.Id == id);
            if (existing is not null)
            {
                return existing;
            }
            else return null;
        }
        catch (Exception)
        {
            throw;
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Googleid"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<User> GetUserByGoogleId(string Googleid, string name)
    {
        // Check if user already exists in DB
        var existing = await _context.Users.AsNoTracking()
              .FirstOrDefaultAsync(p => p.UserName == Googleid);

        //create user if he doesn't exist 
        if (existing is null)
        {
            var create = new CreateUserRequest()
            {
                FullName = name,
                UserName = Googleid,
            };
            var user =  await Create(create);
            return user;    
        }
        else
        {
            return existing;       
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="updateUserRequest"></param>
    /// <returns></returns>
    public async Task Update(UpdateUserRequest updateUserRequest)
    {
        // Check if user already exists in DB
        var existing = await _context.Users.AsNoTracking()
              .FirstOrDefaultAsync(p => p.Id == updateUserRequest.Id);
        try
        {
           
            if (existing is not null)
            {
                var courses = updateUserRequest.Courses;
                if (courses is not null)
                {
                    foreach (var course in courses)
                    {
                        existing?.Courses?.Add(item: new UserCourse { Id = Guid.NewGuid(), UserId = existing.Id, courseId = course, CreatedDate = DateTime.Now.ToUniversalTime(), CreatedBy = updateUserRequest.last_updated_by.ToString() });

                        _context.Users.Add(existing);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}

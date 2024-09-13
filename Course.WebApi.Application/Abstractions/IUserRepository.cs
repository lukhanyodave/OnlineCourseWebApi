using OnlineCourse.WebApi.Application.Dto.Request.UserRequest;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Abstractions;

public  interface IUserRepository
{
    Task<User> Create(CreateUserRequest createCourseRequest);
    Task Update(UpdateUserRequest updateUserRequest);
    Task Delete(Guid id);
    Task<User> GetById(Guid id);
    Task<User> GetUserByGoogleId(string Googleid, string name);
}

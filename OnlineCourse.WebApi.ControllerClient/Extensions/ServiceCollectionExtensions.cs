using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Infrastructure.Queries;
using OnlineCourse.WebApi.Infrastructure.Repository;

namespace OnlineCourse.WebApi.ControllerClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

       
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        return services;
    }
}

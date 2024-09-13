using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Handler;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Command;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Query;
using OnlineCourse.WebApi.Application.Features.UserFeature.Handler;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Command;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;
using OnlineCourse.WebApi.Domain.Entity;
using System.Reflection;


namespace OnlineCourse.WebApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<UpdateUserCommand>), typeof(UpdateUserCommandHandler));
            services.AddScoped(typeof(IRequestHandler<CreateUserCommand, User>), typeof(CreateUserCommandHandler));
            services.AddScoped(typeof(IRequestHandler<GetUserByGoogleIdQuery, User>), typeof(GetUserByGoogleIdQueryHandler));
            services.AddScoped(typeof(IRequestHandler<GetUserByIdQuery, User>), typeof(GetUserByIdQueryHandler));
            services.AddScoped(typeof(IRequestHandler<CreateCourseCommand, Course>), typeof(CreateCourseCommandHandler));
            services.AddScoped(typeof(IRequestHandler<GetAllCoursesQuery, List<Course>>), typeof(GetAllCoursesQueryHandler));
            var assembly = typeof(DependencyInjection).Assembly;
            //services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    };

}

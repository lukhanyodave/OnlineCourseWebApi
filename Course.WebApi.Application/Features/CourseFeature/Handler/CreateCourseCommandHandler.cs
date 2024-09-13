using MediatR;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Command;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.CourseFeature.Handler;

public class CreateCourseCommandHandler :IRequestHandler<CreateCourseCommand,Course>
{
    protected readonly ICourseRepository _courseRepository;
    public CreateCourseCommandHandler(ICourseRepository courseRepository) => _courseRepository = courseRepository;
    public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken) => await _courseRepository.CreateCourse(request.CreateCourseRequest);    
   
}

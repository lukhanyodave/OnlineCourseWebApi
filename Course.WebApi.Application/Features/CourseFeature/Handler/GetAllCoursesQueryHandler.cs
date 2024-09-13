using MediatR;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Query;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.CourseFeature.Handler;
public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery,List<Course>>
{
    protected ICourseRepository _courseQuery;
    public GetAllCoursesQueryHandler(ICourseRepository courseQuery) => _courseQuery = courseQuery;
    public async  Task<List<Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken) => await _courseQuery.GetAll();    
}

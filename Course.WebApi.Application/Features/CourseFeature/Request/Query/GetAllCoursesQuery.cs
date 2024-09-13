

using MediatR;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Query;

public record GetAllCoursesQuery():IRequest<List<Course>>;

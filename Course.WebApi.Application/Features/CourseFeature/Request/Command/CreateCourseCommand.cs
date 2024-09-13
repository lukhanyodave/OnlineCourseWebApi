using MediatR;
using OnlineCourse.WebApi.Application.Dto.Request.CourseRequest;
using OnlineCourse.WebApi.Domain.Entity;


namespace OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Command;

public  record CreateCourseCommand(CreateCourseRequest CreateCourseRequest):IRequest<Course>;

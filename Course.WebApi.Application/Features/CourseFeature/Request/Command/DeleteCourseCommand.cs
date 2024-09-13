using MediatR;


namespace OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Command;

public  record DeleteCourseCommand(Guid id ):IRequest;


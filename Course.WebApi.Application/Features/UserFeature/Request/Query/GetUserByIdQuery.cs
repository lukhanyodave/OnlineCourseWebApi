using MediatR;
using OnlineCourse.WebApi.Domain.Entity;
namespace OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;

public  record GetUserByIdQuery(Guid id):IRequest<User>;

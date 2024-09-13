using MediatR;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;

public record GetUserByUserNameQuery(string UserName) :IRequest<User>;


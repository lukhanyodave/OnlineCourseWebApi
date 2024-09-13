using MediatR;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;

public record GetUserByGoogleIdQuery(string googleIdQuery,string name):IRequest<User>;

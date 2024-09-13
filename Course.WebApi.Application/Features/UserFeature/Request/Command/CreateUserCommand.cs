using MediatR;
using OnlineCourse.WebApi.Application.Dto.Request.UserRequest;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Request.Command;

public record CreateUserCommand(CreateUserRequest CreateUserRequest) :IRequest<User>;


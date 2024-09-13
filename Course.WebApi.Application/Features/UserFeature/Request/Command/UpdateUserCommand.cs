using MediatR;
using OnlineCourse.WebApi.Application.Dto.Request.UserRequest;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Request.Command;

public record UpdateUserCommand(UpdateUserRequest UpdateUserRequest) :IRequest;


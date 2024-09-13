using MediatR;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Command;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Handler;

public  class CreateUserCommandHandler :IRequestHandler<CreateUserCommand,User>
{
    protected IUserRepository _userRepo;
    public CreateUserCommandHandler(IUserRepository userRepo) => _userRepo = userRepo;

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken) => await _userRepo.Create(request.CreateUserRequest);
   
}

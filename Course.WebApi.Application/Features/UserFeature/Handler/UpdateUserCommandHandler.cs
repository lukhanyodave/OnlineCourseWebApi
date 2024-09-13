using MediatR;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Command;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Handler;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    protected IUserRepository _userRepository;
    public UpdateUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken) => await _userRepository.Update(request.UpdateUserRequest);
    
}

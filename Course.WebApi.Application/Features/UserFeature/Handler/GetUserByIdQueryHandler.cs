using MediatR;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;
using OnlineCourse.WebApi.Domain.Entity;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Handler;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    protected readonly IUserRepository _userRepository;
    public GetUserByIdQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;
    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) => await _userRepository.GetById(request.id);
}

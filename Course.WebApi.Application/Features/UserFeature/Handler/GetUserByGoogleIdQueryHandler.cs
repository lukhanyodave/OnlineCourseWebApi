using MediatR;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;
using OnlineCourse.WebApi.Domain.Entity;


namespace OnlineCourse.WebApi.Application.Features.UserFeature.Handler;

public class GetUserByGoogleIdQueryHandler :IRequestHandler<GetUserByGoogleIdQuery,User>
{
    protected readonly IUserRepository _userRepository;
    public GetUserByGoogleIdQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;
    public async Task<User> Handle(GetUserByGoogleIdQuery request, CancellationToken cancellationToken) => await _userRepository.GetUserByGoogleId(request.googleIdQuery, request.name);
   
}

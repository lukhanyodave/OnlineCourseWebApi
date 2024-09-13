using MediatR;

namespace OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;

public record CheckEmailExistQuery(string email):IRequest<bool>;

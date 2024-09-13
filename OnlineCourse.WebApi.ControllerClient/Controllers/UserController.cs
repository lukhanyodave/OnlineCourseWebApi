using MediatR;

using Microsoft.AspNetCore.Mvc;
using OnlineCourse.WebApi.Application.Dto.Request.UserRequest;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Command;
using OnlineCourse.WebApi.Application.Features.UserFeature.Request.Query;

namespace OnlineCourse.WebApi.ControllerClient.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public UserController(IMediator mediator, ILogger logger) {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetUserByGoogleId")]
        public async Task<IActionResult> GetUserByGoogleId(string id,string name )
        {
            try
            {
                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
                    return new BadRequestResult();
                else
                {
                    var user = await _mediator.Send(new GetUserByGoogleIdQuery(id, name), default(CancellationToken));
                    if (user is null)
                        return new NotFoundResult();
                    else
                    {
                        return new OkObjectResult(user);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                return new StatusCodeResult(500);
            }

        }

        /// <summary>
        /// gets user by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return new BadRequestResult();
                else
                {
                    var user = await _mediator.Send(new GetUserByIdQuery(id), default(CancellationToken));
                    if (user is null)
                        return new NotFoundResult();
                    else
                    {
                        return new OkObjectResult(user);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                return new StatusCodeResult(500);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("userName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    return new BadRequestResult();
                else
                {
                    var user = await _mediator.Send(new GetUserByUserNameQuery(userName), default(CancellationToken));
                    if (user is null)
                        return new NotFoundResult();
                    else
                    {
                        return new OkObjectResult(user);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                return new StatusCodeResult(500);
            }
            
        }
        /// <summary>
        /// create application user 
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserRequest createUserDto)
        {
            try
            {
                if (createUserDto is null)
                    return new BadRequestResult();
                else
                { 
                    var results = await _mediator.Send(new CreateUserCommand(createUserDto));
                    if (results is null)
                        return new ConflictResult();
                    else
                        return new CreatedResult("Created user ", results);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                return new StatusCodeResult(500);
            }
        }
        /// <summary>
        /// Update user 
        /// </summary>
        /// <param name="updateUserDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest updateUserDto)
        {
            try
            {
                if (updateUserDto is null)
                    return BadRequest();
                await _mediator.Send(new UpdateUserCommand(updateUserDto));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Exception occurred: {Message}" ,ex.Message);
                return new StatusCodeResult(500);
            }
        }
	
    }
}

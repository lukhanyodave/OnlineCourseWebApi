using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCourse.WebApi.Application.Dto.Request.CourseRequest;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Command;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Query;


namespace OnlineCourse.WebApi.ControllerClient.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public CourseController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// gets all courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                    var courses = await _mediator.Send(new GetAllCoursesQuery(), default(CancellationToken));
                    if (courses is null)
                        return new NotFoundResult();
                    else
                    {
                        return new OkObjectResult(courses);
                    }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                return new StatusCodeResult(500);
            }

        }
        /// <summary>
        /// creates and retunns a new course 
        /// </summary>
        /// <param name="createCourseDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateCourse(CreateCourseRequest createCourseDto)
        {
            try
            {
                if (createCourseDto is null)
                    return new BadRequestResult();
                else
                {
                    var results = await _mediator.Send(new CreateCourseCommand(createCourseDto));
                    if (results is null)
                        return new ConflictResult();
                    else
                        return new CreatedResult("Created course ", results);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                return new StatusCodeResult(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return new BadRequestResult();
                else
                {
                    var request = new DeleteCourseCommand(id);
                    await _mediator.Send(request);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                return new StatusCodeResult(500);
            }
               
        }

    }
}

using OnlineCourse.WebApi.Application.Dto.Request.CourseRequest;
using OnlineCourse.WebApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.WebApi.Application.Abstractions
{
    public interface IUserCourseRepository
    {
        Task<Course> Create(CreateCourseRequest createCourseRequest);
        Task Update(UpdateCourseRequest updateCourseRequest);
        Task Delete(Guid id);
    }
}

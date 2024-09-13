using MediatR;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.WebApi.Application.Features.CourseFeature.Handler
{
    public  class DeleteCourseCommandHandler :IRequestHandler<DeleteCourseCommand>
    {
        protected readonly ICourseRepository _courseRepository;
        public DeleteCourseCommandHandler(ICourseRepository courseRepository) => _courseRepository = courseRepository;

        public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken) => await _courseRepository.DeleteCourse(request.id);
       
    }
}

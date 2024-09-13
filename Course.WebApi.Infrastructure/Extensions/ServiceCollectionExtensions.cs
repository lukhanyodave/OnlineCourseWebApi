using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OnlineCourse.WebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourse.WebApi.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var con = configuration.GetConnectionString("Default");
            services.AddDbContext<CourseDbContext>(options => options.UseInMemoryDatabase(con??""));
        }
    }
}

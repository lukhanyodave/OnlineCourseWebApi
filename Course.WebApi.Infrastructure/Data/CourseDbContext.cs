
using OnlineCourse.WebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourse.WebApi.Infrastructure.Data;

public class CourseDbContext(DbContextOptions<CourseDbContext> options) : DbContext(options)
{
    //properties map to DB tables
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<User>()
    //        .HasMany(c => c.UserFiles)
    //        .WithOne()
    //        .HasForeignKey(c => c.Id);
    //}


}

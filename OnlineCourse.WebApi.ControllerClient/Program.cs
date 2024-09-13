
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using OnlineCourse.WebApi.Application;
using OnlineCourse.WebApi.Application.Abstractions;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Handler;
using OnlineCourse.WebApi.Application.Features.CourseFeature.Request.Query;
using OnlineCourse.WebApi.ControllerClient.Extensions;
using OnlineCourse.WebApi.Domain.Entity;
using OnlineCourse.WebApi.Infrastructure.Extensions;
using OnlineCourse.WebApi.Infrastructure.Repository;
using System.Data;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();



//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var serviceProvider = builder.Services.BuildServiceProvider(); 
var logger = serviceProvider.GetService<ILogger<Program>>(); 
builder.Services.AddSingleton(typeof(ILogger), logger);
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("https://localhost:5001"
                                ).AllowAnyHeader()
                                .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Policy1");
app.UseHttpsRedirection();
app.UseRouting();



app.UseAuthorization();

app.MapControllers();
 
app.Run();

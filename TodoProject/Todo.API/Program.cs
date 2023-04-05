using Todo.Infrastructure;
using Todo.ApplicationLayer;
using Microsoft.AspNetCore.HttpLogging;
using Todo.API.RouteGroups;
using Todo.API.ErrorHandling;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplicationServices();
}

WebApplication app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler(ExceptionHandling.HandleApplicationException);
    app.UseHttpLogging();
    app.UseHttpsRedirection();
    app.MapGroup("/todos").AddTodoEndpoints();
    app.MapGroup("todos/comments").AddTodoCommentsEndpoints();
    app.Run();
}
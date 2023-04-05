using Todo.API.ErrorHandling;
using Todo.API.RouteGroups;
using Todo.ApplicationLayer;
using Todo.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.UseLogging();
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
    app.UseHttpLogging();
    app.UseExceptionHandler(ExceptionHandling.HandleApplicationException);
    app.UseHttpsRedirection();
    app.MapGroup("/todos").AddTodoEndpoints();
    app.MapGroup("todos/comments").AddTodoCommentsEndpoints();
    app.Run();
}
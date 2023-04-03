using Microsoft.AspNetCore.Mvc;
using Todo.ApplicationLayer.Repositories;
using Todo.Contracts.DTO.Import;
using Todo.Domain.Entities;

namespace Todo.API.RouteGroups
{
    public static class TodoEndpoints
    {
        public static RouteGroupBuilder AddTodoEndpoints(this RouteGroupBuilder builder)
        {
            builder.MapGet("/todo/all", GetAllTodoItems)
                .WithName("Get all todo's")
                .WithTags("Getters");

            return builder;
        }

        public static async Task<IResult> GetAllTodoItems(ITodoRepository todoRepository)
        {
            try
            {
                IEnumerable<TodoItem> todoItems = await todoRepository.GetAllTodoItems();
                return Results.Ok(todoItems);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<IResult> AddTodoItem([FromBody] TodoItemCreateRequest createRequest)
        {
            throw new NotImplementedException();
        }
    }
}

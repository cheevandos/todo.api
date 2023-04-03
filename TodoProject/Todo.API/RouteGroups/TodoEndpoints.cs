using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.ApplicationLayer.Repositories;
using Todo.Contracts.DTO.Export;
using Todo.Contracts.DTO.Import;
using Todo.Domain.Entities;

namespace Todo.API.RouteGroups
{
    public static class TodoEndpoints
    {
        public static RouteGroupBuilder AddTodoEndpoints(this RouteGroupBuilder builder)
        {
            builder.MapGet("/todos/all", GetAllTodoItems)
                .WithName("Get all todo's")
                .WithTags("Getters");

            return builder;
        }

        public static async Task<IResult> GetAllTodoItems(
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            try
            {
                IEnumerable<TodoItem> todoItems = await todoRepository.GetAllTodoItems();
                return Results.Ok(mapper.Map<TodoItemDetails>(todoItems));
            } catch (Exception ex)
            {
                return Results.Problem(
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        public static async Task<IResult> AddTodoItem(
            [FromBody] TodoItemCreateRequest createRequest,
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            try
            {
                TodoItem newTodo = mapper.Map<TodoItem>(createRequest);
                await todoRepository.Add(newTodo);
                return Results.Created($"/todos/{newTodo.TodoId}", newTodo);
            }
            catch (Exception ex)
            {
                return Results.Problem(
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }
    }
}
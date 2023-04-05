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
            builder.MapGet("/", GetAllTodoItems)
                .WithName("Get all todo's")
                .WithTags("Read");

            builder.MapGet("/{todoItemId}", GetTodoItem)
                .WithName("Get concrete todo item")
                .WithTags("Read");

            builder.MapPost("/add", AddTodoItem)
                .WithName("Add new todo")
                .WithTags("Create");

            builder.MapDelete("/{todoItemId}", DeleteTodoItem)
                .WithName("Delete todo item with comments")
                .WithTags("Delete");

            builder.MapPatch("/{todoItemId}", UpdateTodoItem)
                .WithName("Update todo title")
                .WithTags("Update");

            return builder;
        }

        public static async Task<IResult> GetAllTodoItems(
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            IEnumerable<TodoItem> todoItems = await todoRepository.GetAllTodoItems();
            return Results.Ok(mapper.Map<IEnumerable<TodoItemDetails>>(todoItems));
        }

        public static async Task<IResult> AddTodoItem(
            [FromBody] TodoItemCreateRequest createRequest,
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            TodoItem newTodo = mapper.Map<TodoItem>(createRequest);
            await todoRepository.Add(newTodo);
            return Results.Created($"/todos/{newTodo.TodoId}", newTodo);
        }

        public static async Task<IResult> DeleteTodoItem(
            long todoItemId,
            ITodoRepository todoRepository
        )
        {
            await todoRepository.Delete(todoItemId);
            return Results.NoContent();
        }

        public static async Task<IResult> GetTodoItem(
            long todoItemId,
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            TodoItem todoItem = await todoRepository.GetTodoItem(todoItemId);
            return Results.Ok(mapper.Map<TodoItemDetails>(todoItem));
        }

        public static async Task<IResult> UpdateTodoItem(
            [FromBody] TodoItemUpdateRequest updateRequest,
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            await todoRepository.Update(mapper.Map<TodoItem>(updateRequest));
            return Results.Ok(updateRequest);
        }
    }
}
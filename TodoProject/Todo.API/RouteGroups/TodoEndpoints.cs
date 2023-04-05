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

        public static async Task<IResult> DeleteTodoItem(
            long todoItemId,
            ITodoRepository todoRepository
        )
        {
            try
            {
                await todoRepository.Delete(todoItemId);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        public static async Task<IResult> GetTodoItem(
            long todoItemId,
            ITodoRepository todoRepository
        )
        {
            try
            {
                await todoRepository.GetTodoItem(todoItemId);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        public static async Task<IResult> UpdateTodoItem(
            [FromBody] TodoItemUpdateRequest updateRequest,
            ITodoRepository todoRepository,
            IMapper mapper
        )
        {
            try
            {
                await todoRepository.Update(
                    mapper.Map<TodoItemUpdateRequest, TodoItem>(updateRequest)
                );
                return Results.Ok(updateRequest);
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
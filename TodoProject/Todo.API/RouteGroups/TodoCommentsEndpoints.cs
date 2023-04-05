using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.ApplicationLayer.Repositories;
using Todo.Contracts.DTO.Export;
using Todo.Contracts.DTO.Import;
using Todo.Domain.Entities;

namespace Todo.API.RouteGroups
{
    public static class TodoCommentsEndpoints
    {
        public static RouteGroupBuilder AddTodoCommentsEndpoints(this RouteGroupBuilder builder)
        {
            builder.MapPost("/", AddComment)
                .WithName("Add new comment")
                .WithTags("Create");

            builder.MapGet("/{todoItemId}", GetTodoComments)
                .WithName("Get todo comments")
                .WithTags("Read");

            return builder;
        }

        public static async Task<IResult> AddComment(
            [FromBody] TodoCommentCreateRequest commentCreateRequest,
            ITodoCommentRepository todoCommentRepository,
            IMapper mapper
        )
        {
            try
            {
                TodoComment newComment = mapper.Map<TodoComment>(commentCreateRequest);
                await todoCommentRepository.Add(newComment);
                return Results.Created(
                    $"/todos/{newComment.TodoItemId}/comments/{newComment.CommentId}",
                    newComment
                );
            }
            catch (Exception ex)
            {
                return Results.Problem(
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        public static async Task<IResult> GetTodoComments(
            long todoItemId,
            ITodoCommentRepository todoCommentRepository,
            IMapper mapper
        )
        {
            try
            {
                IEnumerable<TodoComment> comments =
                    await todoCommentRepository.GetTodoItemComments(todoItemId);
                return Results.Ok(mapper.Map<IEnumerable<TodoCommentDetails>>(comments));
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
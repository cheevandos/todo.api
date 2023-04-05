using System;
namespace Todo.Contracts.DTO.Import
{
    public record TodoCommentCreateRequest(
        long TodoItemId,
        string Content
    );
}
using System;
namespace Todo.Contracts.DTO.Export
{
    public record TodoCommentDetails(
        long CommentId,
        string Content
    );
}
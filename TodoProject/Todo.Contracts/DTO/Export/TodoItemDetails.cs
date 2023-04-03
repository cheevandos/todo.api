namespace Todo.Contracts.DTO.Export
{
    public record TodoItemDetails(
        long TodoId,
        string Title,
        bool IsCompleted,
        DateTime CreateAt,
        string Category,
        string Color,
        string Hash,
        List<TodoCommentDetails> Comments
    );
}
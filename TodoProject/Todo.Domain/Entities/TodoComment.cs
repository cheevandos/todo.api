namespace Todo.Domain.Entities;

public partial class TodoComment
{
    public required long CommentId { get; set; }

    public required string Content { get; set; } = null!;

    public required long TodoItemId { get; set; }

    public virtual TodoItem TodoItem { get; set; } = null!;
}
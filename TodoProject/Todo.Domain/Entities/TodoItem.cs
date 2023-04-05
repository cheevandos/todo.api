using Todo.Domain.Enums;

namespace Todo.Domain.Entities;

public partial class TodoItem
{
    public required long TodoId { get; set; }

    public required string Title { get; set; } = null!;

    public required DateTime CreateAt { get; set; }

    public required bool IsCompleted { get; set; }

    public required TodoCategory? Category { get; set; } = null!;

    public required TodoColor? Color { get; set; } = null!;

    public virtual ICollection<TodoComment> TodoComments { get; } = new List<TodoComment>();
}
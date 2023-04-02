using System;
using System.Collections.Generic;

namespace Todo.Domain.Entities;

public partial class TodoComment
{
    public long CommentId { get; set; }

    public string Content { get; set; } = null!;

    public long TodoItemId { get; set; }

    public virtual TodoItem TodoItem { get; set; } = null!;
}

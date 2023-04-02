using System;
using System.Collections.Generic;

namespace Todo.Domain.Entities;

public partial class TodoItem
{
    public long TodoId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public bool IsCompleted { get; set; }

    public string Category { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<TodoComment> TodoComments { get; } = new List<TodoComment>();
}
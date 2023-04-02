using System;
using Todo.Domain.Entities;

namespace Todo.ApplicationLayer.Repositories
{
    public interface ITodoCommentRepository
    {
        void Add(TodoComment comment);
        IEnumerable<TodoComment> GetTodoItemComments(long todoItemId);
    }
}
using System;
using Todo.Domain.Entities;

namespace Todo.ApplicationLayer.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAllTodoItems();
        void Add(TodoItem todoItem);
        TodoItem GetTodoItem(long todoItemId);
        void Delete(long todoItemId);
        void Update(TodoItem todoItem);
    }
}
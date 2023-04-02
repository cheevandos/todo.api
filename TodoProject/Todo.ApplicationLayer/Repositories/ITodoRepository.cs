using Todo.Domain.Entities;

namespace Todo.ApplicationLayer.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllTodoItems();
        Task Add(TodoItem todoItem);
        Task<TodoItem> GetTodoItem(long todoItemId);
        Task Delete(long todoItemId);
        Task Update(TodoItem todoItem);
    }
}
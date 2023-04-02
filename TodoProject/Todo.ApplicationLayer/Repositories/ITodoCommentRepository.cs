using Todo.Domain.Entities;

namespace Todo.ApplicationLayer.Repositories
{
    public interface ITodoCommentRepository
    {
        Task Add(TodoComment comment);
        Task<IEnumerable<TodoComment>> GetTodoItemComments(long todoItemId);
    }
}
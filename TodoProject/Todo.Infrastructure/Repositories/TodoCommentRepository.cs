using Microsoft.EntityFrameworkCore;
using Todo.ApplicationLayer.Repositories;
using Todo.Domain.Entities;
using Todo.Infrastructure.Persistance;

namespace Todo.Infrastructure.Repositories
{
    public class TodoCommentRepository : ITodoCommentRepository
    {
        private readonly ToDoDbContext context;

        public TodoCommentRepository(ToDoDbContext context)
        {
            this.context = context;
        }

        public async Task Add(TodoComment comment)
        {
            if (await context.TodoItems
                .Include(item => item.TodoComments)
                .SingleOrDefaultAsync(item => item.TodoId == comment.TodoItemId)
                is not TodoItem item
            )
            {
                throw new Exception("Todo not found");
            }
            item.TodoComments.Add(comment);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoComment>> GetTodoItemComments(long todoItemId)
        {
            if (await context.TodoItems
                .AsNoTracking()
                .Include(item => item.TodoComments)
                .SingleOrDefaultAsync(item => item.TodoId == todoItemId)
                is not TodoItem item
            )
            {
                throw new Exception("Todo not found");
            }
            return item.TodoComments;
        }
    }
}
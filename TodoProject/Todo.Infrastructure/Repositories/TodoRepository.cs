using Microsoft.EntityFrameworkCore;
using Todo.ApplicationLayer.Repositories;
using Todo.Domain.Entities;
using Todo.Infrastructure.Persistance;

namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ToDoDbContext context;

        public TodoRepository(ToDoDbContext context)
        {
            this.context = context;
        }

        public async Task Add(TodoItem todoItem)
        {
            if (context.TodoItems.Any(
                item => item.Title == todoItem.Title && 
                item.Category == todoItem.Category
            ))
            {
                throw new Exception("Todo with same title and category already exists");
            }
            todoItem.CreateAt = DateTime.UtcNow;
            await context.TodoItems.AddAsync(todoItem);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long todoItemId)
        {
            if (await context.TodoItems
                .SingleOrDefaultAsync(item => item.TodoId == todoItemId)
                is not TodoItem item
            )
            {
                throw new Exception("Todo item not found");
            }
            context.TodoItems.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItems()
        {
            return await context.TodoItems
                .AsNoTracking()
                .Include(item => item.TodoComments)
                .OrderByDescending(item => item.CreateAt)
                .ToListAsync();
        }

        public async Task<TodoItem> GetTodoItem(long todoItemId)
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
            return item;
        }

        public async Task Update(TodoItem todoItem)
        {
            if (await context.TodoItems
                .SingleOrDefaultAsync(item => item.TodoId == todoItem.TodoId)
                is not TodoItem item
            )
            {
                throw new Exception("Todo not found");
            }
            item.Title = todoItem.Title;
            await context.SaveChangesAsync();
        }
    }
}
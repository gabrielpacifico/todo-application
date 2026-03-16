using Microsoft.EntityFrameworkCore;
using TodoApplication.Context;
using TodoApplication.Models;

namespace TodoApplication.Queries
{
    public static class TodoQueries
    {
        public static async Task<IEnumerable<TodoItem>> GetByName(ApiDbContext context, string? name)
        {
            return await context.TodoItems.AsNoTracking()
                .Where(x => EF.Functions.Like(x.Title, $"%{name}%")).ToListAsync();
        }

        public static async Task<IEnumerable<TodoItem>> GetByStatus(ApiDbContext context, bool? isComplete)
        {
            var searchStatus = context.TodoItems.AsNoTracking();

            if (isComplete.HasValue)
            {
                searchStatus = searchStatus.Where(x => x.isComplete == isComplete);
            }

            return await searchStatus.ToListAsync();
        }
    }
}

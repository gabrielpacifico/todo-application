using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Context;
using TodoApplication.DTO;
using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApiDbContext _context;

        public TodoItemRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetByName(string name)
        {
            var search = await _context.TodoItems.AsNoTracking().Where(x => EF.Functions.Like(x.Title, $"%{name}%")).ToListAsync();
            return search;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TodoApplication.Models;

namespace TodoApplication.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

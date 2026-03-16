using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetByName(string name);
    }
}

using TodoApplication.DTO;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAll();
        Task<TodoItem?> GetById(int id);
        Task<TodoItemResponseDTO> CreateItem(CreateTodoItemDTO item);
        Task<TodoItemResponseDTO> UpdateItem(int id, UpdateTodoItemDTO item);
        Task<TodoItemResponseDTO> DeleteItem(int id);
        Task<IEnumerable<TodoItemResponseDTO>> GetByName(string title);
        Task<IEnumerable<TodoItemResponseDTO>> GetByStatus(bool? isComplete);
       
    }
}

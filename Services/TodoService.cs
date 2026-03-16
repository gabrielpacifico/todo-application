using Microsoft.EntityFrameworkCore;
using TodoApplication.Context;
using TodoApplication.DTO;
using TodoApplication.Exceptions;
using TodoApplication.Models;
using TodoApplication.Queries;

namespace TodoApplication.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApiDbContext _context;

        public TodoService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            var todoItems = await _context.TodoItems.AsNoTracking().ToListAsync();
            return todoItems;
        }

        public async Task<TodoItem?> GetById(int id)
        {
            var todoItem = await _context.TodoItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                throw new NotFoundException("O item com o ID informado não existe.");
            }
            return todoItem;
        }

        public async Task<TodoItemResponseDTO> CreateItem(CreateTodoItemDTO item)
        {
            var newItem = new TodoItem
            {
                Title = item.Title,
                CreatedAt = DateTime.UtcNow,
                isComplete = item.isComplete
            };
            _context.TodoItems.Add(newItem);
            await _context.SaveChangesAsync();

            return TodoItemResponseDTO.ToDTO(newItem);
        }

        public async Task<TodoItemResponseDTO> UpdateItem(int id, UpdateTodoItemDTO item)
        {
            var updatedItem = await _context.TodoItems.FindAsync(id);

            if(updatedItem == null)
            {
                throw new NotFoundException("Item não encontrado.");
            }

            updatedItem.Title = item.Title;
            updatedItem.UpdatedAt = item.UpdatedAt;
            updatedItem.isComplete = item.isComplete;

            await _context.SaveChangesAsync();

            return TodoItemResponseDTO.ToDTO(updatedItem);
        }

        public async Task<TodoItemResponseDTO> DeleteItem(int id)
        {
            var deleteItem = await _context.TodoItems.FindAsync(id);

            if(deleteItem == null)
            {
                throw new NotFoundException("Item não encontrado.");
            }

            _context.TodoItems.Remove(deleteItem);
            await _context.SaveChangesAsync();
            return TodoItemResponseDTO.ToDTO(deleteItem);

        }

        public async Task<IEnumerable<TodoItemResponseDTO>> GetByName(string? title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ValidationException("O título deve ser informado.");
            }
            var result = await TodoQueries.GetByName(_context, title);
            return result.Select(TodoItemResponseDTO.ToDTO);
        }

        public async Task<IEnumerable<TodoItemResponseDTO>> GetByStatus(bool? isComplete)
        {
            var searchByStatus = await TodoQueries.GetByStatus(_context, isComplete);
            return searchByStatus.Select(TodoItemResponseDTO.ToDTO);
        }
    }
}

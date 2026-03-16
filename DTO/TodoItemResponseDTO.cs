using TodoApplication.Models;

namespace TodoApplication.DTO
{
    public class TodoItemResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool isComplete { get; set; }


        // Método para converter a entidade TodoItem em um DTO para retornar ao usuário
        internal static TodoItemResponseDTO ToDTO(TodoItem entity)
        {
            return new TodoItemResponseDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                isComplete = entity.isComplete
            };
        }
    }
}

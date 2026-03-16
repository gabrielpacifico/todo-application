using System.ComponentModel.DataAnnotations;

namespace TodoApplication.DTO
{
    public class CreateTodoItemDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de título é obrigatório.")]
        [StringLength(150)]
        public string? Title { get; set; }
        [Required(ErrorMessage = "O campo de data de criação é obrigatório.")]
        public DateTime CreatedAt { get; set; }
        public bool isComplete { get; set; }
    }
}

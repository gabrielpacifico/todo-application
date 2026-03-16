using System.ComponentModel.DataAnnotations;

namespace TodoApplication.DTO
{
    public class UpdateTodoItemDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de título é obrigatório.")]
        [StringLength(150)]
        public string? Title { get; set; }
        [Required(ErrorMessage = "O campo de data de alteração é obrigatório.")]
        public DateTime UpdatedAt { get; set; }
        public bool isComplete { get; set; }
    }
}

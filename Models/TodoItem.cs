using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de título é obrigatório.")]
        [StringLength(150)]
        public string? Title { get; set; }
        [Required(ErrorMessage = "O campo de data de criação é obrigatório.")]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required(ErrorMessage = "O campo de verificação de conclusão é obrigatório.")]
        public bool isComplete { get; set; }
    }
}

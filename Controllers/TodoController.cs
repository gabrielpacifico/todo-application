using Microsoft.AspNetCore.Mvc;
using TodoApplication.DTO;
using TodoApplication.Models;
using TodoApplication.Services;

namespace TodoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemResponseDTO>>> GetAll()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TodoItemResponseDTO>> GetById(int id)
        {
            var item = await _service.GetById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemResponseDTO>> CreateItem(CreateTodoItemDTO item)
        {
            var createdItem = await _service.CreateItem(item);
            return CreatedAtAction(nameof(GetAll), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TodoItemResponseDTO>> UpdateItem(int id, UpdateTodoItemDTO item)
        {
            var updatedItem = await _service.UpdateItem(id, item);
            return Ok(updatedItem);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var deletedItem = await _service.DeleteItem(id);
            return Ok(deletedItem);
        }

        [HttpGet("searchByName")]
        public async Task<ActionResult<IEnumerable<TodoItemResponseDTO>>> GetByName(string? title)
        {
            var searchedItems = await _service.GetByName(title);
            return Ok(searchedItems);
        }

        [HttpGet("searchByStatus")]
        public async Task<ActionResult<IEnumerable<TodoItemResponseDTO>>> GetByStatus(bool? isComplete)
        {
            var searchByStatus = await _service.GetByStatus(isComplete);
            return Ok(searchByStatus);
        }
    }
}

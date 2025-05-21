using BlazorTodoApp.Server.Data;
using BlazorTodoApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetList")]
    public async Task<IEnumerable<TodoItem>> GetAllItems()
    {
        return await _context.TodoItems.ToListAsync();
    }

    [HttpPost("CreateItem")]
    public async Task<IActionResult> PostItem(TodoItem item)
    {
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpPut("UpdateItem/{id}")]
    public async Task<IActionResult> UpdateItem(int id, TodoItem item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("DeleteItem/{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

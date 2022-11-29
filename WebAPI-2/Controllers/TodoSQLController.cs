using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_2.Data;
using WebAPI_2.Models;

namespace WebAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoSQLController : ControllerBase
    {
        private readonly DataContext _context;

        public TodoSQLController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoSQL>>> Get()
        {
            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoSQL>> Get(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoSQL>>> AddTodo(TodoSQL todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpPatch]
        public async Task<ActionResult<List<TodoSQL>>> UpdateTodo(TodoSQL req)
        {
            var todo = await _context.Todos.FindAsync(req.Id);
            if (todo == null)
            {
                return BadRequest("Not Found");
            }
            todo.Description = req.Description;
            todo.Completed = req.Completed;
            await _context.SaveChangesAsync();

            return Ok(await _context.Todos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TodoSQL>>> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return BadRequest("Not Found");
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return Ok(await _context.Todos.ToListAsync());
        }
    }
}

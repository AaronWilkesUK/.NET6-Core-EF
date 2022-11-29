using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebAPI_2.Models;

namespace WebAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
       private static List<Todo> todos = new List<Todo>
       {
           new Todo
           {
               Id = 1,
               Description = "Go Shopping",
               Completed = false,
           }
        };


        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id) {
            var todo = todos.Find(t => t.Id == id);
            if(todo == null) {
                return BadRequest("Not Found");
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<List<Todo>>> AddTodo(Todo todo)
        {
            todos.Add(todo);
            return Ok(todos);
        }

        [HttpPatch]
        public async Task<ActionResult<List<Todo>>> UpdateTodo(Todo req)
        {
            var todo = todos.Find(t => t.Id == req.Id);
            if (todo == null)
            {
                return BadRequest("Not Found");
            }
            todo.Description = req.Description;
            todo.Completed = req.Completed;
            
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Todo>>> DeleteTodo(int id)
        {
            var todo = todos.Find(t => t.Id == id);
            if (todo == null)
            {
                return BadRequest("Not Found");
            }
            todos.Remove(todo);
            return Ok(todo);
        }
    }
}

using API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BromieBot.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ServiceTodoApi service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> AddTodo([FromBody]Todo todo)
        {
            var result = await service.AddTodo(todo);
            
            if(result == true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

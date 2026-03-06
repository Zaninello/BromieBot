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

        [HttpGet("verify")]
        public async Task<ActionResult> VerifyTodo(
            [FromQuery] long chatId, 
            [FromQuery] string nameTodo
        )
        {
            var result = await service.VerifyTodo(chatId, nameTodo);

            if(result is not null)
            {
                return Ok(result);
            }
            return BadRequest(); 
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTodo(
            [FromQuery] long chatId, 
            [FromQuery] string nameTodo
        )
        {
            var result = await service.DeleteTodo(chatId, nameTodo);

            if(result is true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("edit")]
        public async Task<ActionResult> EditTodo(
            [FromQuery] long chatId,
            [FromQuery] string nameTodo,
            [FromQuery] string newDescription
        )
        {
            var result = await service.EditTodo(chatId, nameTodo, newDescription);
            if(result)
                return Ok($"Todo: {nameTodo} successfully changed!");

            return BadRequest($"Error on the edit process!");
        }
    }
}

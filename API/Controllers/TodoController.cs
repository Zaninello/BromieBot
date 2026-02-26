using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BromieBot.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> AddTodo([FromBody]Todo todo)
        {
            return default;
        }
    }
}

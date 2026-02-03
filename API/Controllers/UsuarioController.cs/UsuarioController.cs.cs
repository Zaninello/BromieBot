using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BromieBot.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> VerificaUsuario()
        {
         return default;   

        } 
    }
}

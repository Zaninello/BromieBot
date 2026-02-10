using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BromieBot.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(ServiceUserApi service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> VerificaUsuario([FromQuery] long chatId)
        {

            service.ServiceVerifica(chatId);
         return default;

        } 
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BromieBot.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(ServiceUserApi service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> VerificaUsuario([FromQuery] User usuario)
        {
            service.ServiceVerifica(usuario);
         return default;

        } 
    }
}

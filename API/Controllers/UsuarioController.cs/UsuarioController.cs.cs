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
        public async Task<ActionResult> AdicionarUsuario([FromBody]User usuario)
        {

            var result = await service.AdicionarUsuario(usuario);
            if(result is true)
            {
                return Ok();                
            } 
            return BadRequest();
        } 
    }
}

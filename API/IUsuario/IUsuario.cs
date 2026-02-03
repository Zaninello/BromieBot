using Microsoft.AspNetCore.Mvc;
using Models;

namespace BromieBot.API;

public interface IUsuario
{
    public Task<ActionResult>VerificarUsuario(User user);
}

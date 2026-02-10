using Microsoft.AspNetCore.Mvc;
using Models;

namespace BromieBot.API;

public interface IUsuario
{
    public bool VerificarUsuario(long chatId);
}

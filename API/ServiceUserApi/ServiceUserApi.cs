using Microsoft.VisualBasic;
using Models;

namespace BromieBot.API;

public class ServiceUserApi
{
    public ServiceUserApi(RepositoryUserApi Repo)
    {
        _repo = Repo;
    }

    private RepositoryUserApi _repo {get;}
    public async Task<bool> AdicionarUsuario(User usuario)
    {
        var result = await _repo.VerificarUsuario(usuario.ChatId);
        if(result is false)
        {
            await _repo.AdicionarUsuario(usuario);
        }
        return true;
    }
}

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
    public bool ServiceVerifica(User user)
    {
        // implementar logica e retorno.
        _repo.VerificarUsuario(user);
        return true;
    }
}

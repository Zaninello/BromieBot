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
    public bool ServiceVerifica(long chatId)
    {
        if(chatId is )
        _repo.VerificarUsuario(chatId);
        return true;
    }
}
